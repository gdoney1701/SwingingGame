using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentumHandler : MonoBehaviour
{
    public Vector3 currentVel;
    bool swinging = false;
    float radius;
    float t = 0;

    private void Start()
    {
        
    }
    public void StartSwinging(Vector3 inputVel, float inputRad)
    {
        swinging = true;
        currentVel = inputVel;
        radius = inputRad;
        GetComponent<Rigidbody>().useGravity = false;
    }

    private void Update()
    {
        if (swinging)
        {
            float linVel = currentVel.z;
            float distanceMoved = linVel * t;
            //Debug.Log(distanceMoved);

            float theta = Mathf.Atan(distanceMoved/radius);
            //print(theta);
            print(Mathf.Cos(theta));
            print(Mathf.Sin(theta));
            Vector2 moveFrame = new Vector2(distanceMoved * Mathf.Cos(theta), distanceMoved * Mathf.Sin(theta));
            //print(moveFrame);
            transform.Translate(moveFrame, Space.World);
            t += Time.deltaTime;
            
        }
    }
}
