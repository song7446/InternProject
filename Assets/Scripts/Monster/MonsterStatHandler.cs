using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatHandler : MonoBehaviour
{
    MonsterData monsterData;
    public float hp { get; private set; }

    [Header("UI")]
    [SerializeField] private Image hpBar;

    public void Init(MonsterData monsterData)
    {
        this.monsterData = monsterData;
        hp = monsterData.MaxHP;
    }

    public void GetDamge(int damage)
    {
        hp = Mathf.Max(0, hp - damage);
        hpBar.fillAmount =  hp / monsterData.MaxHP;

        if (hp == 0)
        {
            ItemManager.Instance.CreateItem(int.Parse(monsterData.DropItem), transform.position);
            Destroy(gameObject);
        }
    }
}