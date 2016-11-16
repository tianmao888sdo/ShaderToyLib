using UnityEngine;
using System.Collections;

public class TestShader : MonoBehaviour {

    public AnimationCurve curve;
    Material m_Material;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CheckSupport()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            if(this.material.shader.isSupported)
            {

            }
        }
    }

    private void CreateMaterial()
    {

    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture dest = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0); ;
        Graphics.Blit(dest, destination, material);
    }

    protected Material material
    {
        get
        {
            if (m_Material == null)
                  {
               m_Material = new Material(Shader.Find("shadertoy/TotalNoob"));
               m_Material.hideFlags = HideFlags.DontSave;
                          }
                     return m_Material;
        }
    }

    protected void OnDisable()
   {  
       if (m_Material != null)  
       {  
          Object.DestroyImmediate(m_Material);  
       }  
    } 

}
