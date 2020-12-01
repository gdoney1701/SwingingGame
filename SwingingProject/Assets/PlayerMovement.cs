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

    void Awake()
    {
        controls = new PlayerControls();

        controls.Movement.Jump.performed += ctx => Jump();
        controls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Move.canceled += ctx => move = Vector2.zero;
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpRange);
        Debug.Log("jumped");
    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime * walkSpeed;
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
}
