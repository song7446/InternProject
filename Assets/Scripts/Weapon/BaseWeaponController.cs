using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeaponController : MonoBehaviour
{
    [SerializeField] protected LayerMask enemyMask;
    
    protected float damage;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
