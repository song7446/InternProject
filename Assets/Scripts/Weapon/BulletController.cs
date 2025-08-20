using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BaseWeaponController
{
    [SerializeField] private LayerMask wallMask;

    public BulletType bulletType;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyMask) != 0)
        {
            collision.GetComponent<BaseStatHandler>().OnDamaged?.Invoke((int)damage);
            BulletManager.Instance.OnDestroyBullet(gameObject, bulletType);
        }
        else if (((1 << collision.gameObject.layer) & wallMask) != 0)
        {
            BulletManager.Instance.OnDestroyBullet(gameObject, bulletType);
        }
    }
}