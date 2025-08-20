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
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimController = GetComponent<PlayerAnimController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
        playerAnimController.OnMoveAnim(moveInput);
    }
    
    private void Move()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}