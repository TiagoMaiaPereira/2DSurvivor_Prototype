using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{


    private Vector2 pointerPosition;
    private PlayerControlls playerControlls;


    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }

    private void Update()
    {
        pointerPosition = TurnPointer();

        transform.right = (pointerPosition - (Vector2)transform.position).normalized;
       
    }


    private Vector3 TurnPointer()
    {
        Vector3 mousePos = playerControlls.Gameplay.Look.ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
