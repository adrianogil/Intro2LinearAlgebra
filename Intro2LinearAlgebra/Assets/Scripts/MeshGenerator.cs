using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public abstract class MeshGenerator : MonoBehaviour {

    protected abstract Mesh GenerateMesh();

    public void Start () {
        UpdateMesh();
    }

	/// <summary>
    /// Update Mesh 
    /// </summary>
	public void UpdateMesh () {
		
        Mesh newMesh = GenerateMesh();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }

        meshFilter.mesh = newMesh;
	}	
}

#if UNITY_EDITOR
[CustomEditor(typeof(MeshGenerator))]
public class MeshGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    
        MeshGenerator editorObj = target as MeshGenerator;
    
        if (editorObj == null) return;
        
        if (GUILayout.Button("Update Mesh"))
        {
            editorObj.UpdateMesh();
        }
    }

}
#endif
