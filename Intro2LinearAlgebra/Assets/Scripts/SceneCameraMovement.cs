using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum MovementMode
{
    FromPosition,
    FromReference
}

public class SceneCameraMovement : MonoBehaviour
{
    public MovementMode movementMode;
    [HideInInspector]
    public Vector3 scenePosition;
    [HideInInspector]
    public Transform referencePosition;
}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneCameraMovement))]
public class SceneCameraMovementEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    
        SceneCameraMovement editorObj = target as SceneCameraMovement;
    
        if (editorObj == null) return;
        
        if (editorObj.movementMode == MovementMode.FromPosition)
        {
            editorObj.scenePosition = EditorGUILayout.Vector3Field("Scene position", editorObj.scenePosition);
        } else {
            editorObj.referencePosition = (Transform) EditorGUILayout.ObjectField("Reference", 
                        editorObj.referencePosition, typeof(Transform), true, null);
        }

        if (GUILayout.Button("Move"))
        {
            if (editorObj.movementMode == MovementMode.FromPosition)
            {
                SceneView.lastActiveSceneView.LookAt(editorObj.scenePosition);
            } else {
                SceneView.lastActiveSceneView.LookAt(editorObj.referencePosition.position, editorObj.referencePosition.rotation);
            }
            
            SceneView.lastActiveSceneView.Repaint();
        }
        if (GUILayout.Button("Load Position"))
        {
            editorObj.scenePosition = SceneView.lastActiveSceneView.pivot;
        }
        if (GUILayout.Button("Save"))
        {
            GameObject newGO = new GameObject("SceneCameraPosition");
            newGO.transform.parent = editorObj.transform;
            newGO.transform.position = editorObj.scenePosition;
            newGO.transform.rotation = SceneView.lastActiveSceneView.rotation;
        }
    }

}
#endif