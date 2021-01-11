﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    public float jumpRange = 2;

    public Vector2 move;
    Vector2 aim;
    public Vector3 momentum;
    public float walkSpeed = 5;
    public bool onGround = true;
    public int jumpMax = 2;
    int jumpOn = 0;
    bool anotherJump = true;
    float vel;
    public Rigidbody playerBod;

    public float downForceMod = -30;

    public GameObject hookFab;
    public GameObject impactFab;
    public int hookVel;
    public bool hookAround = false;
    public bool onSwing = false;

    public List<GameObject> localTargets = new List<GameObject>();
    public float targetArc;
    GameObject currentHook;
    bool striking = false;

    void Awake()
    {
        controls = new PlayerControls();
        ResetGravity();
        controls.Movement.Jump.performed += ctx => Jump();
        controls.Movement.GroundPound.performed += ctx => Pound();
        controls.Movement.FireHook.started += ctx => HookShot();
        controls.Movement.FireHook.canceled += ctx => EndSwing();

        controls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Move.canceled += ctx => move = Vector2.zero;

        controls.Movement.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        controls.Movement.Strike.started += ctx => striking = true;
        controls.Movement.Strike.canceled += ctx => striking = false;
        //controls.Movement.Aim.canceled += ctx => aim = Vector2.zero;

        
    }

    void Jump()
    {
        if (anotherJump && !onSwing)
        {
            playerBod.drag = 2;
            ResetGravity();

            playerBod.velocity = new Vector3(vel/2, jumpRange, 0);
            //gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpRange);
            jumpOn++;
            StartCoroutine(FallHandle(false));


            if (jumpOn >= jumpMax)
            {
                anotherJump = false;
                jumpOn = 0;
            }

        }
    }

    void Pound()
    {
        if (!onGround && !onSwing)
        {
            playerBod.velocity = new Vector3(0, downForceMod*playerBod.velocity.magnitude, 0);
        }
    }

    void HookShot()
    {
        if (!hookAround)
        {
            for (int i = 0; i < localTargets.Count; i++)
            {

                GameObject targetCheck = localTargets[i];
                var heading = (targetCheck.transform.position - gameObject.transform.position).normalized;
                Vector2 headingV2 = new Vector2(heading.x, heading.y);
                var cone = Mathf.Cos(targetArc * Mathf.Deg2Rad);

                //Debug.DrawRay(gameObject.transform.position, heading, Color.cyan, 20);

                if (Vector2.Dot(move.normalized, headingV2) > cone)
                {
                    currentHook = Instantiate(hookFab, gameObject.transform.position, gameObject.transform.rotation);
                    currentHook.GetComponent<HookHandler>().attackVector = gameObject.transform.position - targetCheck.transform.position;
                    currentHook.GetComponent<Rigidbody>().velocity = new Vector3(headingV2.x, headingV2.y, 0) * hookVel;
                    hookAround = true;
                    //Debug.DrawRay(gameObject.transform.position, aim, Color.green, 20);

                }
                else
                {
                    //Debug.DrawRay(gameObject.transform.position, aim, Color.red, 20);
                }
            }
        }
        
    }
    IEnumerator FallHandle(bool offHook)
    {
        if (!offHook)
        {
            yield return new WaitForSeconds(.5f);
        }
        playerBod.drag = 0;
        Physics.gravity = new Vector3(0, -30, 0);
    }

    private void Update()
    {
        if (!onSwing)
        {
            float speedMod = walkSpeed * 0.75f;
            if (onGround)
            {
                speedMod = walkSpeed;
                momentum.y = 0;
            }
            else
            {
                momentum.y = playerBod.velocity.y;
            }
            Vector2 m = new Vector2(move.x, 0) * Time.deltaTime * speedMod;
            momentum.x = playerBod.velocity.x + (speedMod*move.normalized.x);
            transform.Translate(m, Space.World);
            vel = m.x * Time.deltaTime;
            //momentum.z = new Vector2(momentum.x, momentum.y).magnitude;
        }

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
            if (striking)
            {
                ImpactZone();
            }
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
        playerBod.drag = 2;
        ResetGravity();
    }
    void ResetGravity()
    {
        Physics.gravity = new Vector3(0, -20, 0);
    }
    void ImpactZone()
    {
        GameObject revealSphere = Instantiate(impactFab, gameObject.transform.position, transform.rotation);
        float scaleMod = Mathf.Sqrt(Mathf.Abs(playerBod.velocity.magnitude));
        Debug.Log(playerBod.velocity);
        revealSphere.GetComponent<ImpactBehavior>().initGrow(scaleMod);
    }
    public void targetHandler(bool entering, GameObject targetDelta)
    {
        if (entering)
        {
            localTargets.Add(targetDelta);
        }
        else
        {
            localTargets.Remove(targetDelta);
        }
    }

    public void EndSwing()
    {
        if (hookAround)
        {
            MomentumHandler playerMomentum = GetComponent<MomentumHandler>();

            if (playerMomentum.connected)
            {
                onSwing = false;
                playerBod.useGravity = true;
                playerBod.isKinematic = false;
                playerMomentum.connected = false;
                playerMomentum.swinging = false;
                playerBod.velocity = playerMomentum.currentVel.magnitude * playerMomentum.releaseVector.normalized*1.5f;
                Destroy(currentHook);
                hookAround = false;
                jumpOn = 0;
                anotherJump = true;
                StartCoroutine(FallHandle(true));
            }
            else
            {
                Destroy(currentHook);
                hookAround = false;
            }
        }
    }
}
