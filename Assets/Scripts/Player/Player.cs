using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimController playerAnimController;
    public PlayerAnimController PlayerAnimController => playerAnimController;
    
    private PlayerMoveController playerMoveController;
    public PlayerMoveController PlayerMoveController => playerMoveController;
    
    private PlayerStatHandler playerStatHandler;
    public PlayerStatHandler PlayerStatHandler => playerStatHandler;
    
    private PlayerAttackController playerAttackController;
    public PlayerAttackController PlayerAttackController => playerAttackController;

    private void Awake()
    {
        playerAnimController = GetComponent <PlayerAnimController>();
        playerMoveController = GetComponent <PlayerMoveController>();
        playerStatHandler = GetComponent <PlayerStatHandler>();
        playerAttackController = GetComponent <PlayerAttackController>();
    }
}
