using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MultiPass : ScriptableRenderPass
{
    private readonly List<ShaderTagId> shaderTagIds;

    public MultiPass(List<string> tags)
    {
        shaderTagIds = new List<ShaderTagId>();
        foreach (string tag in tags)
        {
            shaderTagIds.Add(new ShaderTagId(tag));
        }

        this.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        FilteringSettings filter = FilteringSettings.defaultValue;

        foreach (ShaderTagId id in shaderTagIds)
        {
            DrawingSettings drawingSettings = CreateDrawingSettings(id, ref renderingData, SortingCriteria.CommonOpaque);
            context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filter);
        }

        context.Submit();
    }
}
