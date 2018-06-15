using UnityEngine;


[ExecuteInEditMode]
public class VectorAddition : MonoBehaviour
{
    public Vector a, b;

    public void Update()
    {
        transform.position = a.transform.position + b.transform.position;
    }
    
}