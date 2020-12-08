using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    public float jumpRange = 2;

    Vector2 move;
    Vector2 aim;
    public float walkSpeed = 5;
    public bool onGround = true;
    public int jumpMax = 2;
    int jumpOn = 0;
    bool anotherJump = true;
    float vel;
    public Rigidbody playerBod;

    public float downForce = -30;

    public GameObject hook;
    public int hookVel;
    public bool hookAround = false;

    public List<GameObject> localTargets = new List<GameObject>();
    public float targetArc;

    void Awake()
    {
        controls = new PlayerControls();
        ResetGravity();
        controls.Movement.Jump.performed += ctx => Jump();
        controls.Movement.GroundPound.performed += ctx => Pound();
        controls.Movement.FireHook.started += ctx => HookShot();

        controls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Move.canceled += ctx => move = Vector2.zero;

        controls.Movement.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        //controls.Movement.Aim.canceled += ctx => aim = Vector2.zero;

        
    }

    void Jump()
    {
        if (anotherJump)
        {
            playerBod.drag = 2;
            ResetGravity();

            playerBod.velocity = new Vector3(vel/2, jumpRange, 0);
            //gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpRange);
            Debug.Log("jumped");
            jumpOn++;
            StartCoroutine(FallHandle());


            if (jumpOn >= jumpMax)
            {
                anotherJump = false;
                jumpOn = 0;
            }

        }
    }

    void Pound()
    {
        if (!onGround)
        {
            playerBod.velocity = new Vector3(0, downForce, 0);
        }
    }

    void HookShot()
    {
        //GameObject hookSpawn = Instantiate(hook, gameObject.transform.position, gameObject.transform.rotation);
        //hookSpawn.GetComponent<Rigidbody>().velocity = new Vector3(aim.x, aim.y, 0) * hookVel;
        //hookAround = true;

        for(int i =0; i<localTargets.Count; i++)
        {

            GameObject targetCheck = localTargets[i];
            var heading = (targetCheck.transform.position - gameObject.transform.position).normalized;
            Vector2 headingV2 = new Vector2(heading.x, heading.y);
            var cone = Mathf.Cos(targetArc * Mathf.Deg2Rad);
            
            Debug.DrawRay(gameObject.transform.position, heading, Color.cyan, 20);

            if (Vector2.Dot(aim.normalized,headingV2) > cone)
            {
                //Debug.Log("Target Locked");
                //GameObject hookSpawn = Instantiate(hook, gameObject.transform.position, gameObject.transform.rotation);
                //hookSpawn.GetComponent<HookHandler>().attackVector = targetCheck.transform.position - gameObject.transform.position;
                //hookSpawn.GetComponent<Rigidbody>().velocity = new Vector3(headingV2.x, headingV2.y, 0) * hookVel;
                //hookAround = true;
                Debug.DrawRay(gameObject.transform.position, aim, Color.green, 20);

            }
            else
            {
                Debug.DrawRay(gameObject.transform.position, aim, Color.red, 20);
            }
        }
    }
    IEnumerator FallHandle()
    {
        yield return new WaitForSeconds(.5f);
        playerBod.drag = 0;
        Physics.gravity = new Vector3(0, -30, 0);
    }

    private void Update()
    {
        float speedMod = walkSpeed * 0.75f;
        if (onGround)
        {
            speedMod = walkSpeed;
        }
        Vector2 m = new Vector2(move.x, 0) * Time.deltaTime * speedMod;
        transform.Translate(m, Space.World);
        vel = m.x/Time.deltaTime;
        //Debug.Log(Physics.gravity);
    }

    private void OnEnable()
    {
        controls.Movement.Enable();
    }
    private void OnDisable()
    {
        controls.Movement.Disable();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            ResetGround();
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            onGround = false;
        }
    }

    void ResetGround()
    {
        onGround = true;
        jumpOn = 0;
        anotherJump = true;
        Debug.Log("Wompf");
        playerBod.drag = 2;
        ResetGravity();
    }
    void ResetGravity()
    {
        Physics.gravity = new Vector3(0, -20, 0);
    }
    public void targetHandler(bool entering, GameObject targetDelta)
    {
        if (entering)
        {
            localTargets.Add(targetDelta);
            Debug.Log(localTargets);
        }
        else
        {
            localTargets.Remove(targetDelta);
        }
    }
}
