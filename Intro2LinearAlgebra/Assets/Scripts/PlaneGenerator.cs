using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlaneGenerator : MeshGenerator {

	protected override Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();
        
        mesh.vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 1f),
        };

        mesh.triangles = new int[]
        {
            0, 1, 2
        };


        return mesh;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlaneGenerator))]
public class PlaneGeneratorEditor : MeshGeneratorEditor {

}
#endif