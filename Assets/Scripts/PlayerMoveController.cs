using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    private PlayerAnimController playerAnimController;
    
    SpriteRenderer spriteRenderer;
    
    [SerializeField]private Camera camera;
    Vector2 playerPos;
    private Vector2 mouseWorldPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimController = GetComponent<PlayerAnimController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        Vector2 mousePos =inputValue.Get<Vector2>();
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
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}