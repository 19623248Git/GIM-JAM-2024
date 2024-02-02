using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DungeonGenerationData))]
public class DungeonGenerationDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DungeonGenerationData data = (DungeonGenerationData)target;

        // Draw default inspector
        DrawDefaultInspector();

        GUILayout.Space(10);

        // Allow dragging and dropping scenes into the list
        for (int i = 0; i < data.scenesToLoad.Count; i++)
        {
            EditorGUI.BeginChangeCheck();
            SceneAsset sceneAsset = (SceneAsset)EditorGUILayout.ObjectField("Scene", data.scenesToLoad[i], typeof(SceneAsset), false);
            if (EditorGUI.EndChangeCheck())
            {
                data.scenesToLoad[i] = sceneAsset;
                EditorUtility.SetDirty(target);
            }
        }
    }
}
