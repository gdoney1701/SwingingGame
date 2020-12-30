using System.Collections;
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
    public float zoomDistance = 0;
    float initRad;
    bool zooming;
    public Vector3 releaseVector;

    public int directionMod = 1;
    

    public void StartSwinging(Vector3 inputVel, Vector2 inputRad, Vector3 target, float minRad)
    {

        currentVel = inputVel;
        radius = inputRad.magnitude;
        if(minRad < radius)
        {
            zoomDistance = minRad;
            zooming = true;
            initRad = inputRad.magnitude;
        }
        else
        {
            zooming = false;
        }
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        center = target;
        Vector3 delta = new Vector3(0, 0, 0);

        delta = gameObject.transform.position - new Vector3(target.x, target.y, 0);
        angle = Mathf.Atan2(delta.y, delta.x);
        inputDot = Vector3.Dot(inputVel.normalized, inputRad);
        DirectionHandler();
        connected = true;
    }
    void DirectionHandler()
    {
        Vector3 toCenter = transform.position - center;
        Vector3 perpVel = new Vector3(currentVel.y, -currentVel.x, 0);
        if(Vector3.Dot(perpVel,toCenter) > 0)
        {
            directionMod = 1;
        }
        else
        {
            directionMod = -1;
        }
    }

    private void Update()
    {
        if (connected)
        {
            if(zooming)
            {
                radius = Mathf.Lerp(initRad, zoomDistance-1, t);
                t += Time.deltaTime * 5;
                if (t >= 1f)
                {
                    zooming = false;
                    t = 0;
                }
            }
            Vector3 travel = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            if (radius > 4 && !zooming)
            {
                float preRad = radius;
                radius -= Time.deltaTime * 0.1f;
                if (currentVel.magnitude <= maxSpeed)
                {
                    currentVel *= 1 + (preRad - radius);
                }
            }

            playerMove = gameObject.GetComponent<PlayerMovement>().move;
            angle += (currentVel.magnitude * Time.deltaTime / radius) * (1.5f*directionMod);
            releaseVector = (center + travel)- transform.position;
            transform.position = center + travel;

            }

        }

    public void ResetSpin()
    {
        t = 0;
    }
}
