using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{


    private Vector2 pointerPosition;

    [Header ("Input Actions")]
    [SerializeField] private InputActionReference look;
    private void Update()
    {
        pointerPosition = GetPointerInput();

        transform.right = (pointerPosition - (Vector2)transform.position).normalized;
       
    }

    private Vector2 GetPointerInput()
    {
        Vector3 pointerRotation = look.action.ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(pointerRotation);
    }
}
