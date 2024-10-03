using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class MultipassRenderFeature : ScriptableRendererFeature
{
    public List<string> lightModeTags;

    private MultiPass pass;

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(pass);
    }

    public override void Create()
    {
        pass = new MultiPass(lightModeTags);
    }
}
