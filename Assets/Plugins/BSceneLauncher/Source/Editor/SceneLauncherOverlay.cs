using System.Linq;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Plugins.BSceneLauncher.Source.Editor
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
            var row = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    alignItems = Align.Center
                }
            };
            
            var scenePopup = new PopupField<string>(
                "Scene",
                _sceneNames.ToList(),
                _selectedSceneIndex
            );
            scenePopup.style.flexGrow = 1;
            scenePopup.RegisterValueChangedCallback(evt =>
            {
                _selectedSceneIndex = _sceneNames.ToList().IndexOf(evt.newValue);
            });

            var openButton = new Button(OnOpenButtonClicked) {text = "Open"};
            var playButton = new Button(OnPlayButtonClicked) {text = "▶ Play"};
            
            openButton.style.marginLeft = 4;
            playButton.style.marginTop = 6;
            playButton.style.width = Length.Percent(100);
            
            row.Add(scenePopup);
            row.Add(openButton);
            root.Add(row);
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
        private void OnOpenButtonClicked()
        {
            if (_scenePaths == null || _scenePaths.Length == 0)
                return;

            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                return;

            EditorSceneManager.OpenScene(_scenePaths[_selectedSceneIndex]);
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
