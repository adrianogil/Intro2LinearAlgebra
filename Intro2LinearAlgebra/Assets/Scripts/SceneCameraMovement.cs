using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneCameraMovement : MonoBehaviour
{
    public Vector3 scenePosition;   
}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneCameraMovement))]
public class SceneCameraMovementEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    
        SceneCameraMovement editorObj = target as SceneCameraMovement;
    
        if (editorObj == null) return;
        
        if (GUILayout.Button("Move"))
        {
            SceneView.lastActiveSceneView.pivot = editorObj.scenePosition;
            SceneView.lastActiveSceneView.Repaint();
        }
        if (GUILayout.Button("Load Position"))
        {
            editorObj.scenePosition = SceneView.lastActiveSceneView.pivot;
        }
    }

}
#endif