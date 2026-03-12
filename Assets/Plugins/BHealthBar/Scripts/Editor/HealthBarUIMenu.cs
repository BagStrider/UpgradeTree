using UnityEditor;
using UnityEngine;

namespace Plugins.BHealthBar.Scripts.Editor
{
    public class HealthBarUIMenu
    {
        private static void Spawn<T>() where T : DefaultHealthBar
        {
            T prefab = AssetDatabase.LoadAssetAtPath<T>($"Assets/Plugins/BHealthBar/Prefabs/{typeof(T).Name}.prefab");

            if (prefab == null)
            {
                Debug.LogError($"❌ Не найден префаб по пути Assets/Plugins/BHealthBar/Prefabs/{typeof(T).Name}.prefab");
                return;
            }

            T instance = (T)PrefabUtility.InstantiatePrefab(prefab);

            Undo.RegisterCreatedObjectUndo(instance, "Spawn BHealthBar");

            if (Selection.activeTransform != null)
            {
                instance.transform.SetParent(Selection.activeTransform, false);
            }
            
            Selection.activeObject = instance;
        }
        
        [MenuItem("GameObject/UI/BHealthBar/"+ nameof(DefaultHealthBar), false, 10)]
        private static void SpawnDefaultHealthBar()
        {
            Spawn<DefaultHealthBar>();
        }

        [MenuItem("GameObject/UI/BHealthBar/"+ nameof(NumericHealthBar), false, 10)]
        private static void SpawnNumericHealthBar()
        {
            Spawn<NumericHealthBar>();
        }
        [MenuItem("GameObject/UI/BHealthBar/"+ nameof(IconHealthBar), false, 10)]
        private static void SpawnIconHealthBar()
        {
            Spawn<IconHealthBar>();
        }
        [MenuItem("GameObject/UI/BHealthBar/"+ nameof(NumericIconHealthBar), false, 10)]
        private static void SpawnNumericIconHealthBar()
        {
            Spawn<NumericIconHealthBar>();
        }
    }
}