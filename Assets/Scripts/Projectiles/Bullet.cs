using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private int damage = 10;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;

        if (target.CompareTag("Damageable")){
            target.GetComponent<Health>().Damage(damage);
        }

        Destroy (gameObject);
    }
}
