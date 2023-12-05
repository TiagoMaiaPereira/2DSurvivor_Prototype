using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private PlayerControlls playerControlls;

    [Header("Other Settings")]
    [SerializeField] private string logMessage;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
        playerControlls.Gameplay.Use.started += Use;
    }

    private void OnDisable()
    {
        playerControlls.Disable();
        playerControlls.Gameplay.Use.started -= Use;
    }

    private void Use(InputAction.CallbackContext obj)
    {
        Debug.Log(logMessage);
    }
}
