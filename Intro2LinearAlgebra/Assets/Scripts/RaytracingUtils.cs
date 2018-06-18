using UnityEngine;

public struct RayData
{
    public bool hit;
    public Color color;
}

public class RaytracingUtils
{

    public static RayData Raycast(Ray ray)
    {
        RayData rayData;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,  100))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
            rayData.hit = true;
            rayData.color = Color.blue;
        } else {
            Debug.DrawLine(ray.origin, ray.origin + 100f*ray.direction, Color.red);
            rayData.hit = false;
            rayData.color = Color.black;
        }

        return rayData;
    }
    
}