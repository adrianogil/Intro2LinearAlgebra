using UnityEngine;

public class RaytracingRendering : MonoBehaviour
{
    
    public RenderTexture renderTexture;
    protected Texture2D tempTexture = null;

    protected void Render(int x, int y, Color color)
    {
        if (tempTexture == null)
        {
            tempTexture = new Texture2D(renderTexture.width, renderTexture.height);
        }
        tempTexture.SetPixel(x, y, color);
    }


    protected void UpdateRender()
    {
        tempTexture.Apply();
        Graphics.Blit(tempTexture, renderTexture);
    }
}