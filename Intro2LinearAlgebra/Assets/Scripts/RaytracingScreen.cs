using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RaytracingScreen : RaytracingRendering {

    public Color backgroundColor;

    Transform cameraTransform;

    private float height, width;

    void Start()
    {
        UpdateScreen();
    }

	// Use this for initialization
	public void UpdateScreen () {

        cameraTransform = Camera.main.transform;

        transform.position = cameraTransform.position + cameraTransform.forward * Camera.main.nearClipPlane;
        transform.rotation = Quaternion.LookRotation(cameraTransform.forward, cameraTransform.up);

        height = 2f * Camera.main.nearClipPlane * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad);
        width = height * (Screen.width * 1f/ Screen.height);

        transform.localScale = new Vector3(width, height, 1f);
	}
	

    void OnDrawGizmos()
    {
        // Vector3 screenOrigin = transform.position + 
        //     (0.5f) * height * cameraTransform.up + 
        //     (-0.5f) * width * cameraTransform.right;

        // float dx = width / renderTexture.width;
        // float dy = height / renderTexture.height;

        // screenOrigin = screenOrigin + 0.5f * dx * cameraTransform.right - 
        //     0.5f * dy * cameraTransform.up;

        // Gizmos.color = Color.black;
        // Gizmos.DrawSphere(screenOrigin, 0.1f);
    }

	// Update is called once per frame
	void Update () {

        Vector3 screenOrigin = transform.position + 
            (0.5f) * height * cameraTransform.up + 
            (-0.5f) * width * cameraTransform.right;

        float dx = width / renderTexture.width;
        float dy = height / renderTexture.height;

        screenOrigin = screenOrigin + 0.5f * dx * cameraTransform.right - 
            0.5f * dy * cameraTransform.up;

        for (int x = 0; x < renderTexture.width; x++)
        {
            for (int y = 0; y < renderTexture.height; y++)
            {
                Ray ray = new Ray(cameraTransform.position, 
                    (screenOrigin + x*dx*cameraTransform.right 
                                  - y*dy*cameraTransform.up
                      - cameraTransform.position).normalized
                    );
                RayData rayData = RaytracingUtils.Raycast(ray);
                if (rayData.hit)
                {
                    Render(x,y, rayData.color);
                } else {
                    Render(x,y, backgroundColor);
                }
            }
        }

        UpdateRender();
	}
}


#if UNITY_EDITOR
[CustomEditor(typeof(RaytracingScreen))]
public class RaytracingScreenEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    
        RaytracingScreen editorObj = target as RaytracingScreen;
    
        if (editorObj == null) return;
        
        if (GUILayout.Button("Update Screen"))
        {
            editorObj.UpdateScreen();
        }
    }

}
#endif