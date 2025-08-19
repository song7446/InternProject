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
    
    private Vector2 playerPos;
    private Vector2 mouseWorldPos;

    
    private void FixedUpdate()
    {
        Look();
    }

    private void OnFire(InputValue inputValue)
    {
        
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
        Vector2 direction = mouseWorldPos - (Vector2)weaponSR.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        weaponSR.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        weaponSR.transform.position = playerPos + direction * 0.1f;
    }
}