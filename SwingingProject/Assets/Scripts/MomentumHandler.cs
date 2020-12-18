﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MomentumHandler : MonoBehaviour
{
    public Vector3 currentVel;
    public bool swinging = false;
    public bool connected = false;
    public float radius;
    float t = 0;
    float initAngle;

    public float angle;
    Vector3 center;
    Vector2 playerMove;
    float inputDot = 0;

    public float maxSpeed = 20;

    public void StartSwinging(Vector3 inputVel, Vector2 inputRad, Vector3 target)
    {

        currentVel = inputVel;
        radius = inputRad.magnitude;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        center = target;
        Vector3 delta = new Vector3(0, 0, 0);

        delta = gameObject.transform.position - new Vector3(target.x, target.y, 0);
        print(delta);

        print(Mathf.Atan2(6.1f, 3.2f) / Mathf.PI);
        angle = Mathf.Atan2(delta.y, delta.x);

        print("Angle is " + angle/Mathf.PI);
        inputDot = Vector3.Dot(inputVel.normalized, inputRad);

        connected = true;
    }

    private void Update()
    {
        if (connected)
        {

            Vector3 travel = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            if (radius > 4)
            {
                float preRad = radius;
                radius -= Time.deltaTime * 0.1f;
                if(currentVel.magnitude <= maxSpeed)
                {
                    currentVel *= 1 + (preRad - radius);
                }
            }

            playerMove = gameObject.GetComponent<PlayerMovement>().move;
            angle += (currentVel.magnitude * Time.deltaTime / radius) *1.5f;
            //currentVel.x += playerMove.x;
            //currentVel.y += playerMove.y;

            if (swinging)
            {
                transform.position = center + travel;
            }
            else
            {
                Vector3 maintainSpeed = currentVel * Time.deltaTime;
                transform.position = Vector3.Lerp(maintainSpeed + transform.position, center + travel, t);
                t += Time.deltaTime;
                if (t >= 1)
                {
                    swinging = true;
                    t = 0;
                }
            }
        }

    }

    public void ResetSpin()
    {
        t = 0;
    }
}
