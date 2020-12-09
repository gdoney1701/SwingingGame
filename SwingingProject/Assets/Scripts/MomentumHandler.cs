using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MomentumHandler : MonoBehaviour
{
    public Vector3 currentVel;
    bool swinging = false;
    float radius;
    float t = 0;
    float initAngle;

    public float angle;
    Vector2 center;
    Vector2 playerMove;

    private void Awake()
    {
        playerMove = gameObject.GetComponent<PlayerMovement>().move;

    }
    public void StartSwinging(Vector3 inputVel, float inputRad, Vector2 target)
    {

        currentVel = inputVel;
        radius = inputRad;
        GetComponent<Rigidbody>().useGravity = false;
        center = target;
        Vector2 travel = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))* radius;
        angle = Mathf.Deg2Rad * Vector3.SignedAngle(transform.position, travel, center);
        print("Angle is " + angle);

        swinging = true;
    }

    private void Update()
    {
        if (swinging)
        {
            //float linVel = currentVel.z;
            //float distanceMoved = linVel * Time.deltaTime;
            //float theta = Mathf.Atan(distanceMoved/radius);
            //print(Mathf.Cos(theta));
            //print(Mathf.Sin(theta));
            //Vector2 moveFrame = new Vector2(distanceMoved * Mathf.Cos(theta), distanceMoved * Mathf.Sin(theta));
            //transform.Translate(moveFrame, Space.World);
            //t += Time.deltaTime;


            int clockMod = 0;
            //clockwise motion if evaluates correctly, counterclockwise otherwise
            if (currentVel.x > 0 && currentVel.y > 0 || currentVel.x < 0 && currentVel.y < 0)
            {
                clockMod = 1;
            }
            else
            {
                clockMod = -1;
            }
            radius -= currentVel.z * Time.deltaTime * 0.1f;
            angle += currentVel.z * Time.deltaTime / radius * clockMod;
            Vector2 travel = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
            transform.position = center + travel;

        }
    }
}
