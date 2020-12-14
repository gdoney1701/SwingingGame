using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MomentumHandler : MonoBehaviour
{
    public Vector3 currentVel;
    bool swinging = false;
    bool connected = false;
    float radius;
    float t = 0;
    float initAngle;

    public float angle;
    Vector3 center;
    Vector2 playerMove;
    float inputDot = 0;

    private void Awake()
    {
        playerMove = gameObject.GetComponent<PlayerMovement>().move;

    }
    public void StartSwinging(Vector3 inputVel, Vector2 inputRad, Vector3 target)
    {

        currentVel = inputVel;
        radius = inputRad.magnitude;
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().isKinematic = true;
        center = target;

        Vector3 delta = gameObject.transform.position - new Vector3(target.x, target.y+radius, 0);
        angle = Mathf.Atan2(delta.y, delta.x);

        print("Angle is " + angle);
        inputDot = Vector3.Dot(inputVel.normalized, inputRad);

        connected = true;
    }

    private void Update()
    {
        if (connected)
        {

            Vector3 travel = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
            if (radius > 1)
            {
                float preRad = radius;
                radius -= currentVel.z * Time.deltaTime * 0.1f;
                currentVel *= 1 + (preRad - radius);
            }

            angle += currentVel.z * Time.deltaTime / radius;

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
                }
            }
        }

    }
}
