using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlaneGenerator : MeshGenerator {

    public Vector a, b;

	protected override Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();
        
        mesh.vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),
            a.position,
            b.position,
            a.position + b.position
        };

        mesh.triangles = new int[]
        {
            0, 1, 2,
            3, 2, 1
        };


        return mesh;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlaneGenerator))]
public class PlaneGeneratorEditor : MeshGeneratorEditor {

}
#endif