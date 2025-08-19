using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    private PlayerAnimController playerAnimController;

    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private SpriteRenderer playerSR;

    [SerializeField] private Camera camera;
    private Vector2 playerPos;
    private Vector2 mouseWorldPos;

    [SerializeField] private SpriteRenderer weaponSR;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimController = GetComponent<PlayerAnimController>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
        playerAnimController.OnMoveAnim(moveInput);
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        mouseWorldPos = camera.ScreenToWorldPoint(mousePos);
    }

    private void Move()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
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
        Vector2 direction = mouseWorldPos - (Vector2)weaponSR.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        weaponSR.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        weaponSR.transform.position = playerPos + direction * 0.1f;
    }
}