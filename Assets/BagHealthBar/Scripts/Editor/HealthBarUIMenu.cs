using UnityEditor;
using UnityEngine;

namespace BagHealthBar.Scripts.Editor
{
    public class HealthBarUIMenu
    {
        [MenuItem("GameObject/UI/HealthBar", false, 10)]
        private static void Spawn()
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/BagHealthBar/Prefabs/HealthBar.prefab");

            if (prefab == null)
            {
                Debug.LogError("❌ Не найден префаб по пути Assets/BagHealthBar/Prefabs/HealthBar.prefab");
                return;
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

            Undo.RegisterCreatedObjectUndo(instance, "Spawn HealthBar");

            if (Selection.activeTransform != null)
            {
                instance.transform.SetParent(Selection.activeTransform, false);
            }
            
            Selection.activeObject = instance;
        }
    }
}