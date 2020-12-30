using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InterceptPointTest : MonoBehaviour
{
    PlayerControls demoCTRL;
    public GameObject target;
    public GameObject clone;
    public bool create = false;

    void Awake()
    {
        demoCTRL = new PlayerControls();
        demoCTRL.Movement.TestSpawn.performed += ctx => print("Button");

    }

    void MeasureIntercept()
    {
        print("Understood");
        Vector3 delta = gameObject.transform.position - target.transform.position;
        float radius = delta.magnitude;
        float angle = Mathf.Atan2(delta.y, delta.x);
        Vector3 travel = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        Instantiate(clone, travel, gameObject.transform.rotation);
        create = false;

        //print("Angle at 1,0 " Vector)
    }
    private void Update()
    {
        if (create)
        {
            MeasureIntercept();
        }
    }

}
