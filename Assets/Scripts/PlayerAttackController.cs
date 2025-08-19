using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSR;
    [SerializeField] private Camera camera;
    [SerializeField] private SpriteRenderer weaponSR;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;

    private Vector2 playerPos;
    private Vector2 mouseWorldPos;

    public float detectionRange = 5f;
    public float fireDelay = 1f;
    private float fireTimer = 0f;
    public LayerMask enemyLayer;
    public bool isDetecting = true;

    private List<Transform> enemies = new List<Transform>();

    private void Update()
    {
        if (isDetecting)
        {
            DetectEnemies();
        }
    }

    private void FixedUpdate()
    {
        Look();

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            AutoFire();
            fireTimer = fireDelay;       
        }
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        mouseWorldPos = camera.ScreenToWorldPoint(mousePos);
    }

    private void Look()
    {
        playerPos = transform.position;
        if (playerPos.x > mouseWorldPos.x)
        {
            playerSR.flipX = true;
            weaponSR.flipY = true;
        }
        else
        {
            playerSR.flipX = false;
            weaponSR.flipY = false;
        }

        RotateWeapon();
    }

    private void RotateWeapon()
    {
        Vector2 direction = mouseWorldPos - (Vector2)playerPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weaponSR.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        float weaponOffset = 0.5f;
        weaponSR.transform.position = playerPos + direction.normalized * weaponOffset;
    }

    private void DetectEnemies()
    {
        enemies.Clear();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            enemies.Add(hit.transform);
        }
    }

    private void AutoFire()
    {
        if (enemies.Count > 0)
        {
            Vector2 direction = mouseWorldPos - (Vector2)weaponSR.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion bulletAngle = Quaternion.Euler(0, 0, angle - 90);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletAngle, null);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * 5f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}