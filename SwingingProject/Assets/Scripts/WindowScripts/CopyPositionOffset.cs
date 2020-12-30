using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class CopyPositionOffset : MonoBehaviour
{
    public Transform transformToCopy;
    public Vector3 offset;


    // Update is called once per frame
    void UpdateTest()
    {
        transform.position = transformToCopy.position + offset;
        transform.rotation = transformToCopy.rotation;
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += UpdateCamera;

    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= UpdateCamera;
    }

    void UpdateCamera(ScriptableRenderContext context,Camera camera)
    {
        UpdateTest();
    }
}
