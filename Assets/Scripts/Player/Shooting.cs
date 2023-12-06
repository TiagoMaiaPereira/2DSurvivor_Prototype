using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private PlayerControlls playerControlls;

    [Header("Other Settings")]
    [SerializeField] private string logMessage;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
        playerControlls.Gameplay.Shoot.started += Fire;
    }

    private void OnDisable()
    {
        playerControlls.Disable();
        playerControlls.Gameplay.Shoot.started -=Fire;    
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Debug.Log(logMessage);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
