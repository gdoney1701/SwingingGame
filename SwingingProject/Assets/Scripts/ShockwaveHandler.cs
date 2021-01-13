using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveHandler : MonoBehaviour
{
    public List<Renderer> affectedShaders;
    public float effectMaxDistance;
    bool pulseActive = false;
    public float pulseSpeed = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        Renderer shadertoWork = collision.collider.GetComponent<Renderer>();

        int layerMask = 1 << 9;
        Collider[] collisionPlanes = Physics.OverlapSphere(transform.position, effectMaxDistance, layerMask);
        foreach(Collider groundObject in collisionPlanes)
        {
            Renderer localShader = groundObject.GetComponent<Renderer>();
            affectedShaders.Add(localShader);
            localShader.material.SetVector("_Shockwave_Position", transform.position);
            localShader.material.SetFloat("_Shockwave_Enabled", 1);
        }
        pulseActive = true;
        InitiatePulse(shadertoWork);
        Debug.Log(collision.relativeVelocity);


    }

    void InitiatePulse(Renderer groundPlane)
    {
        
    }
    private void Update()
    {
        if (pulseActive)
        {
            float movement = Time.deltaTime * pulseSpeed;
            Debug.Log(movement);
            if (affectedShaders.Count != 0)
            {
                foreach (Renderer shader in affectedShaders)
                {
                    float currentDistance = shader.material.GetFloat("_Shockwave_Distance");
                    currentDistance += movement;
                    shader.material.SetFloat("_Shockwave_Distance", currentDistance);

                    if (currentDistance >= shader.material.GetFloat("_Shockwave_MaxDistance"))
                    {
                        affectedShaders.Remove(shader);
                    }
                }
            }
            else
            {
                pulseActive = false;
            }


        }
    }
}
