using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[ExecuteInEditMode]
public class Vector : MonoBehaviour
{
    public bool normalize;
    public bool hideTransformHandles;
    public Color color = Color.red;

    public void Update()
    {
        if (normalize)
        {
            transform.position = transform.position.normalized;
        }
    }

    public Vector3 position
    {
        get {
            return transform.localPosition;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Vector))]
[CanEditMultipleObjects]
public class VectorEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    
        Vector editorObj = target as Vector;
    
        if (editorObj == null) return;

        Tools.hidden = editorObj.hideTransformHandles;
        
    }

    private void OnSceneGUI() {
        Vector editorObj = target as Vector;

        Handles.color = editorObj.color;
        Vector3 position = Vector3.zero;

        if (editorObj.transform.parent != null)
        {
            position = editorObj.transform.parent.position;
        }

        float arrowSize = (editorObj.transform.position - position).magnitude;

        Handles.ArrowHandleCap( 0, position, Quaternion.LookRotation(editorObj.transform.position - position), 
                arrowSize, EventType.Repaint);
        
    }

}
#endif