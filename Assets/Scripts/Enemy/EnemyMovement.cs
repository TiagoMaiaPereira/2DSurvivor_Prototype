using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float movementSpeed = 5f;
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.transform.position, movementSpeed * Time.deltaTime);

        if (health != null)
        {
            if (health.isDead)
            {
                Destroy(gameObject);
            }
        }
    }
}
