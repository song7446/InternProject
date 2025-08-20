using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;


public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    private Tilemap tilemap;
    [SerializeField] private List<GameObject> monsterPrefabs;

    private List<Vector2> validPositions = new List<Vector2>();
    
    List<GameObject> monsters = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        
        monsterPrefabs = new List<GameObject>();
        GameObject monsterPrefab1 = Resources.Load<GameObject>("Prefabs/Enemy0");
        monsterPrefabs.Add(monsterPrefab1);
        GameObject monsterPrefab2 = Resources.Load<GameObject>("Prefabs/Enemy2");
        monsterPrefabs.Add(monsterPrefab2);
        
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                Vector2 worldPos = tilemap.CellToWorld(pos) + tilemap.tileAnchor;
                validPositions.Add(worldPos);
            }
        }

        CreateMonster();
    }

    private void Start()
    {
        InvokeRepeating("RecycleMonster", 1f, 3f);
    }

    private void CreateMonster()
    {
        foreach (var monsterPrefab in monsterPrefabs)
        {
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range(0, monsterPrefabs.Count);
                int randPos = Random.Range(0, validPositions.Count);
                GameObject monster = Instantiate(monsterPrefab, validPositions[randPos], Quaternion.identity, transform);
                MonsterStatHandler statHandler = monster.GetComponent<MonsterStatHandler>();
                statHandler.Init(DataManager.Instance.GetRandomMonsterData());
                monsters.Add(monster);
                monster.SetActive(false);
            }
        }
    }

    private void RecycleMonster()
    {
        int rand = Random.Range(0, monsters.Count);
        int randPos = Random.Range(0, validPositions.Count);
        
        GameObject monster = monsters[rand];
        monster.transform.position = validPositions[randPos];
        monsters.RemoveAt(rand);
        monster.SetActive(true);
    }
    
    public void OnDead(GameObject monster)
    {
        monster.SetActive(false);
        monsters.Add(monster);
    }
}