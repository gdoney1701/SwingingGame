using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBehavior : MonoBehaviour
{
    public float growLim;
    float startTime;
    bool startCall = false;

    void Update()
    {
        if (startCall)
        {
            float t = (Time.time - startTime) / 2;
            float growFrame = Mathf.SmoothStep(0, growLim, t);
            transform.localScale = Vector3.one * growFrame;
        }

    }
    public void initGrow(float toGrow)
    {
        growLim = toGrow;
        startTime = Time.time;
        startCall = true;
    }
}
