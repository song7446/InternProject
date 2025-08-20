using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseWeaponController
{
    public void DisableWeapon()
    {
        gameObject.SetActive(false);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyMask) != 0)
        {
            collision.GetComponent<BaseStatHandler>().OnDamaged.Invoke((int)damage); 
        }
    }
}
