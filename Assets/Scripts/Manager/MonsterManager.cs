using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    
    [SerializeField] private Transform monsterSpawnPos;
    [SerializeField] private GameObject[] monsterPrefabs;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreateMonster();
        // InvokeRepeating("CreateMonster", 1f, 3f);
    }

    public void CreateMonster()
    {
        int rand = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[rand], monsterSpawnPos.position, Quaternion.identity);
        MonsterStatHandler statHandler = monster.GetComponent<MonsterStatHandler>();
        statHandler.Init(DataManager.Instance.GetRandomMonsterData());
    }
}
