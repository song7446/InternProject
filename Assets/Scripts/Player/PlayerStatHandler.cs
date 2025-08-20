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

    private void Awake()
    {
        hp = 100;
        maxHp = 100;

        attack = 60;
        defense = 10;

        detectionRange = 5;
        fireDelay = 0.5f;

    }

    protected override void Start()
    {
        base.Start();
        OnItemPickedUp += ApplyItemEffect;
    }


    protected override void ApplyDamage(int damage)
    {
        hp = Mathf.Max(0, hp - damage);
        hpBar.fillAmount = hp / maxHp;

        if (hp == 0)
        {
            GameManager.Instance.player.PlayerAnimController.OnDeadAnim();
            Time.timeScale = 0;
        }
    }

    public override int GetDamageStat()
    {
        return (int)attack;
    }

    private void ApplyItemEffect(ItemData itemData)
    {
        hp += itemData.MaxHP;
        attack += itemData.MaxAtk;
        defense += itemData.MaxDef;
    }
}