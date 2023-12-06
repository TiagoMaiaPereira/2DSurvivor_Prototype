using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [Header ("General Settings")]
    [SerializeField] private float speed = 5;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDirection;


    //PlayerInput Read
    private PlayerControlls playerInput;
    

    [Header ("Dash Settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float dashDuration = 0.25f;
    private bool canDash;
    private bool isDashing;

    private void Awake()
    {
        playerInput = new PlayerControlls();
        canDash = true;
        isDashing = false;
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        moveDirection = playerInput.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2 (moveDirection.x * speed, moveDirection.y * speed);

    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Gameplay.Dash.started += StartDash;

    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Gameplay.Dash.started -= StartDash;
    }

    private IEnumerator Dash() 
    {
        canDash = false;
        isDashing = true;
        rb.velocity= new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
       
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void StartDash(InputAction.CallbackContext obj)
    {
        if(canDash)
        {
            StartCoroutine(Dash());
        }
    }
}
