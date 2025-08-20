using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MonsterStatHandler : BaseStatHandler
{
    public MonsterData monsterData { get; private set; }

    public void Init(MonsterData monsterData)
    {
        this.monsterData = monsterData;
        hp = monsterData.MaxHP;
    }

    protected override void GetDamge(int damage)
    {
        hp = Mathf.Max(0, hp - damage);
        hpBar.fillAmount =  hp / monsterData.MaxHP;

        if (hp == 0)
        {
            string[] itemIds = monsterData.DropItem.Split(',');
            int rand = Random.Range(0, itemIds.Length);
            int itemId = int.Parse(itemIds[rand].Trim());
            ItemManager.Instance.CreateItem(itemId, transform.position);
            Destroy(gameObject);
        }
    }
}