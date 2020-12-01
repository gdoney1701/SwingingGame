using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    public float jumpRange = 2;
    Vector2 move;
    public float walkSpeed = 5;
    public bool onGround = true;
    public int jumpMax = 2;
    int jumpOn = 0;
    bool anotherJump = true;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Movement.Jump.performed += ctx => Jump();
        controls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Move.canceled += ctx => move = Vector2.zero;
    }

    void Jump()
    {
        if (anotherJump)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpRange);
            Debug.Log("jumped");
            jumpOn++;
        }

        if (jumpOn >= jumpMax)
        {
            anotherJump = false;
            jumpOn = 0;
        }

    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, 0) * Time.deltaTime * walkSpeed;
        transform.Translate(m, Space.World);
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
    }
}
