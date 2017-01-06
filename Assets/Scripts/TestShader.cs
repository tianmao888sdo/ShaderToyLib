using UnityEngine;
using System.Collections;

/// <summary>
/// 用于测试shader
/// </summary>
public class TestShader : MonoBehaviour
{
    public enum ShaderType
    {
        Standard,//标准的表面shader
        Unlit,//普通shader
        ImageEffect,//屏幕特效shader
        Compute//计算shader
    }

    public AnimationCurve curve;
    public Shader[] shaders;

    /// <summary>
    /// 选择的索引
    /// </summary>
    public int selectIndex = 0;

    /// <summary>
    /// 
    /// </summary>
    public ShaderType shaderType= ShaderType.Unlit;

    private Material m_Material;
    private GameObject m_capsule;

    private void Start()
    {
        if (shaderType == ShaderType.Unlit)//单独创建胶囊体
        {
            m_capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            m_capsule.GetComponent<Renderer>().sharedMaterial = material;
        }
    }

    /// <summary>
    /// 检查是否支持屏幕特效
    /// </summary>
    private bool ImageEffectSupport
    {
        get
        {
            return SystemInfo.supportsImageEffects && material.shader.isSupported;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(shaderType== ShaderType.ImageEffect&& ImageEffectSupport)
        {
            RenderTexture dest = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0); ;
            Graphics.Blit(dest, destination, material);
        }
    }

    /// <summary>
    /// 获取材质
    /// </summary>
    protected Material material
    {
        get
        {
            if (m_Material == null)
            {
               m_Material = new Material(Shader.Find(shaders[selectIndex].name));
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

       if(m_capsule!=null)
        {
            Object.DestroyImmediate(m_capsule);
        }
    } 
}
