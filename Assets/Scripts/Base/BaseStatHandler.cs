using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseStatHandler : MonoBehaviour
{
    public Action<int> OnDamaged;

    protected float hp;

    protected virtual void Start()
    {
        OnDamaged += ApplyDamage;
    }

    [Header("UI")]
    [SerializeField] protected Image hpBar;
    
    protected abstract void ApplyDamage(int damage);
    
    public abstract int GetDamageStat();
}
