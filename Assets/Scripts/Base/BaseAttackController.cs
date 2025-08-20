using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttackController : MonoBehaviour
{
    protected abstract void DetectEmeny();
    protected abstract void AutoAttack();

    protected float fireTimer;
    protected float detectionRange;
    protected float fireDelay;

    protected List<Transform> enemies;

    protected GameObject bulletPrefab;
    
    [SerializeField] protected LayerMask enemyLayer;

    protected virtual void Update()
    {
        DetectEmeny();
    }

    protected virtual void FixedUpdate()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            if (enemies.Count > 0)
            {
                AutoAttack();
                fireTimer = fireDelay;
            }
        }
    }
}
