using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatHandler : MonoBehaviour
{   
    MonsterData monsterData;
    public float HP { get; private set; }

    public void Init(MonsterData monsterData)
    {
        this.monsterData = monsterData;
        HP = monsterData.MaxHP;       
    }
    
    public void GetDamge(int damage)
    {
        HP -= damage;
        Debug.Log($"데미지 {damage} 받음 남은 체력 {HP}");
    }
}
