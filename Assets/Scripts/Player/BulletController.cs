using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private LayerMask wallMask;
    
    protected float damage;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
