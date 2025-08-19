using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    private PlayerAnimController playerAnimController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimController = GetComponent<PlayerAnimController>();
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
        playerAnimController.OnMoveAnim(moveInput);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}