using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [Header ("Input Actions")]
    [SerializeField] private InputActionReference shoot;

    [Header("Other Settings")]
    [SerializeField] private string logMessage;

    private void OnEnable()
    {
        shoot.action.started += Fire;
    }

    private void OnDisable()
    {
        shoot.action.started -=Fire;    
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Debug.Log(logMessage);
    }
}
