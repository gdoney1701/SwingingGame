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
        //HingeJoint playerHinge = player.AddComponent<HingeJoint>();
        //HingeSetup(playerHinge, collision.gameObject);




    }

    //void HingeSetup(HingeJoint hinge, GameObject staticBody)
    //{
    //    //hinge.useMotor = true;
    //    hinge.autoConfigureConnectedAnchor = false;
    //    hinge.connectedBody = staticBody.GetComponent<Rigidbody>();
    //    //hinge.anchor = attackVector;
    //    hinge.anchor = new Vector3(attackVector.x, attackVector.y+3, 0);
    //    hinge.axis = new Vector3(0, 0, 1);
    //    hinge.connectedAnchor = new Vector3(0, 0.5f, 0);



    //}
}
