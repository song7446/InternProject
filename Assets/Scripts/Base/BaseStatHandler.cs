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
        OnDamaged += GetDamge;
    }

    [Header("UI")]
    [SerializeField] protected Image hpBar;
    
    protected abstract void GetDamge(int damage);
}
