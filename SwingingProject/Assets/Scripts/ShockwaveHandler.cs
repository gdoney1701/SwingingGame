using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveHandler : MonoBehaviour
{
    public List<Renderer> affectedShaders;
    public float effectMaxDistance;
    bool pulseActive = false;
    public float pulseSpeed = 2f;
    float t = 0;
    private void OnCollisionEnter(Collision collision)
    {
        affectedShaders.Clear();
        Renderer shadertoWork = collision.collider.GetComponent<Renderer>();
        Debug.Log("bonk");
        int layerMask = 1 << 9;
        Collider[] collisionPlanes = Physics.OverlapSphere(transform.position, effectMaxDistance, layerMask);
        Vector3 impactVel = collision.relativeVelocity;
        float shockwaveIntensity = impactVel.magnitude/2;
        foreach(Collider groundObject in collisionPlanes)
        {
            Renderer localShader = groundObject.GetComponent<Renderer>();
            affectedShaders.Add(localShader);
            localShader.material.SetFloat("_Shockwave_Distance", 0);
            localShader.material.SetVector("_Shockwave_Position", transform.position);
            localShader.material.SetFloat("_Shockwave_Enabled", 1);
            localShader.material.SetFloat("_Shockwave_MaxDistance", effectMaxDistance);
            localShader.material.SetFloat("_Shockwave_Intensity", shockwaveIntensity);
        }
        pulseActive = true;
        t = 0;


    }

    void InitiatePulse(Renderer groundPlane)
    {
        
    }
    private void Update()
    {
        if (pulseActive)
        {
            t += Time.deltaTime;
            float movement = pulseSpeed*Time.deltaTime * Mathf.Exp(-2*t);
            float currentDistance = 0;
            foreach (Renderer shader in affectedShaders)
            {
                currentDistance = shader.material.GetFloat("_Shockwave_Distance");
                currentDistance += movement;
                shader.material.SetFloat("_Shockwave_Distance", currentDistance);


            }
            if (currentDistance >= effectMaxDistance || Mathf.Approximately(0,movement))
            {
                pulseActive = false;
                affectedShaders.Clear();
                t = 0;
            }


        }
    }

}
