using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHandler : MonoBehaviour
{

    GameObject hingePoint;
    public Vector2 attackVector;


    private void OnCollisionEnter(Collision collision)
    {
        hingePoint = collision.gameObject;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().onSwing = true;
        player.GetComponent<MomentumHandler>().StartSwinging(player.GetComponent<PlayerMovement>().momentum, attackVector, 
            collision.transform.position);

    }

}
