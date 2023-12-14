using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private PlayerControlls playerControlls;
    private IInteractable _interactableObject;

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
        if(_interactableObject != null)
        {
            _interactableObject.Interact();
        }
    }

    public void SetInteractable(IInteractable interactable)
    {
        _interactableObject = interactable;
    }
}
