using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BaseWeaponController
{
    [SerializeField] private LayerMask wallMask;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyMask) != 0)
        {
            collision.GetComponent<BaseStatHandler>().OnDamaged.Invoke((int)damage); 
            Destroy(gameObject);
        }
        else if (((1 << collision.gameObject.layer) & wallMask) != 0)
        {
            Destroy(gameObject);
        }
    }
}
