using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [Header ("Input Actions")]
    [SerializeField] private InputActionReference use;

    [Header("Other Settings")]
    [SerializeField] private string logMessage;

    private void OnEnable()
    {
        use.action.started += Use;
    }

    private void OnDisable()
    {
        use.action.started -= Use;
    }

    private void Use(InputAction.CallbackContext obj)
    {
        Debug.Log(logMessage);
    }
}
