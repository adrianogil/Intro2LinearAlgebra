using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RaytracingScreen : MonoBehaviour {

    public Color backgroundColor;

    Transform cameraTransform;

    void Start()
    {
        UpdateScreen();
    }

	// Use this for initialization
	public void UpdateScreen () {

        cameraTransform = Camera.main.transform;

        transform.position = cameraTransform.position + cameraTransform.forward * Camera.main.nearClipPlane;
        transform.rotation = Quaternion.LookRotation(cameraTransform.forward, cameraTransform.up);

        float height = 2f * Camera.main.nearClipPlane * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad);
        float width = height * (Screen.width * 1f/ Screen.height);

        transform.localScale = new Vector3(width, height, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RayData rayData = RaytracingUtils.Raycast(ray);
        if (rayData.hit)
        {
            // Render(x,y, rayData.color);
        } else {
            // Render(x,y, backgroundColor);
        }

        // UpdateRender();
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