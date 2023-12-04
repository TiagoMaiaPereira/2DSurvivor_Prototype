using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoordinates : MonoBehaviour
{
    [Header("Object Configuration")]

    [SerializeField] 
    private Rigidbody2D rb;
    [SerializeField] 
    private float speed;

    [Header("Toggle Vector3.right")]

    [SerializeField] 
    private bool toggleVector = false;

    private void FixedUpdate()
    {
        if (rb != null)
        {
            if (toggleVector)
            {
                rb.velocity = Vector3.right * speed;
            }
            else
            {
                rb.velocity = transform.right * speed;
            }
        }
    }
}
