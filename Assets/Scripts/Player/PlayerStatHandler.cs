using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatHandler : BaseStatHandler
{
    public float maxHp{ get; private set; }

    public float attack{ get; private set; }
    public float defense{ get; private set; }

    public float detectionRange { get; private set; }
    public float fireDelay { get; private set; }
    
    public Action<ItemData> OnItemPickedUp;

    protected override void Start()
    {
        base.Start();
        
        hp = 100;
        maxHp = 100;

        attack = 10;
        defense = 10;

        detectionRange = 5;
        fireDelay = 0.5f;
        
        OnItemPickedUp += ApplyItemEffect;
    }


    protected override void GetDamge(int damage)
    {
        hp = Mathf.Max(0, hp - damage);
        hpBar.fillAmount = hp / maxHp;

        if (hp == 0)
        {
            GameManager.Instance.player.PlayerAnimController.OnDeadAnim();
        }
    }

    private void ApplyItemEffect(ItemData itemData)
    {
        hp += itemData.MaxHP;
        attack += itemData.MaxAtk;
        defense += itemData.MaxDef;
    }
}