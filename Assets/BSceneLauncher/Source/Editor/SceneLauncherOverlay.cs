using System.Linq;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace BSceneLauncher.Source.Editor
{
    [Overlay(typeof(SceneView), "Scene Launcher")]
    public class SceneLauncherOverlay : Overlay
    {
        private const string PreviousSceneKey = "SceneLauncher.PreviousScenePath";

        private int _selectedSceneIndex;
        private string[] _sceneNames;
        private string[] _scenePaths;

        static SceneLauncherOverlay()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        public override VisualElement CreatePanelContent()
        {
            RefreshScenes();

            var root = new VisualElement
            {
                style =
                {
                    paddingLeft = 6,
                    paddingRight = 6,
                    paddingTop = 4,
                    paddingBottom = 4
                }
            };

            var scenePopup = new PopupField<string>(
                "Scene",
                _sceneNames.ToList(),
                _selectedSceneIndex
            );

            scenePopup.RegisterValueChangedCallback(evt =>
            {
                _selectedSceneIndex = _sceneNames.ToList().IndexOf(evt.newValue);
            });

            var playButton = new Button(OnPlayButtonClicked)
            {
                text = "▶ Play"
            };

            root.Add(scenePopup);
            root.Add(playButton);

            return root;
        }

        private void OnPlayButtonClicked()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
                return;
            }

            if (_scenePaths == null || _scenePaths.Length == 0)
                return;

            var currentScenePath = SceneManager.GetActiveScene().path;
            EditorPrefs.SetString(PreviousSceneKey, currentScenePath);

            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(_scenePaths[_selectedSceneIndex]);
            EditorApplication.isPlaying = true;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredEditMode)
                return;

            if (!EditorPrefs.HasKey(PreviousSceneKey))
                return;

            var previousScenePath = EditorPrefs.GetString(PreviousSceneKey);
            EditorPrefs.DeleteKey(PreviousSceneKey);

            if (!string.IsNullOrEmpty(previousScenePath))
            {
                EditorSceneManager.OpenScene(previousScenePath);
            }
        }

        private void RefreshScenes()
        {
            _scenePaths = EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .ToArray();

            _sceneNames = _scenePaths
                .Select(System.IO.Path.GetFileNameWithoutExtension)
                .ToArray();

            if (_selectedSceneIndex >= _sceneNames.Length)
                _selectedSceneIndex = 0;
        }
    }
}
