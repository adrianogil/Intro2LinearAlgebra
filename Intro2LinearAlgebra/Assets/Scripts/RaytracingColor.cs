using UnityEngine;

public class RaytracingColor : MonoBehaviour
{
    public Color color;

    private MeshRenderer _meshRenderer;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _meshRenderer.sharedMaterial.SetColor("_Color", color);
    }
}