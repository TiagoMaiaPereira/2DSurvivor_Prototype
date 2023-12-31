using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHP = 100;
    private int currentHP;
    public bool isDead { get; private set; }

    private void Awake()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    public void Damage(int damage)
    {
        currentHP = currentHP - damage;
    }

    private void Die()
    {
        isDead = true;
    }
}
