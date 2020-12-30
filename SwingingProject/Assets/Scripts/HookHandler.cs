using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHandler : MonoBehaviour
{

    GameObject hingePoint;
    public Vector3 attackVector;
    


    private void OnCollisionEnter(Collision collision)
    {
        hingePoint = collision.gameObject;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().onSwing = true;
        float minRad = impactDetection(hingePoint.transform.position);
        player.GetComponent<MomentumHandler>().StartSwinging(player.GetComponent<PlayerMovement>().momentum, attackVector, 
            collision.transform.position, minRad);

    }

    float impactDetection(Vector3 targetPos)
    {
        int layerMask = 1 << 9;
        Collider[] hitColliders = Physics.OverlapSphere(targetPos, attackVector.magnitude, layerMask);
        if(hitColliders.Length > 0)
        {
            float minRad = attackVector.magnitude;
            float compareRad = 0;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                Vector3 dist = targetPos - hitColliders[i].ClosestPoint(targetPos);
                compareRad = dist.magnitude;
                if(compareRad < minRad)
                {
                    minRad = compareRad;
                }
            }
            return minRad;
        }
        else
        {
            return attackVector.magnitude;
        }

    }
}
