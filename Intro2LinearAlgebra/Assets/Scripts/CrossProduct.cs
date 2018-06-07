using UnityEngine;


[ExecuteInEditMode]
public class CrossProduct : MonoBehaviour
{
    public Vector a, b;

    public void Update()
    {
        transform.position = Vector3.Cross(a.transform.position,
                                           b.transform.position);
    }
    
}