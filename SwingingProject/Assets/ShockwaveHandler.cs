using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Renderer shadertoWork = collision.collider.GetComponent<Renderer>();
        shadertoWork.material.SetVector("_Shockwave_Position",transform.position);
        shadertoWork.material.SetFloat("_Shockwave_Enabled", 1);

    }
}
