using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;


public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject[] monsterPrefabs;

    private List<Vector2> validPositions = new List<Vector2>();

    private void Awake()
    {
        Instance = this;

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                Vector2 worldPos = tilemap.CellToWorld(pos) + tilemap.tileAnchor;
                validPositions.Add(worldPos);
            }
        }
    }

    private void Start()
    {
        // InvokeRepeating("CreateMonster", 1f, 2f);
        CreateMonster();
    }

    public void CreateMonster()
    {
        int rand = Random.Range(0, monsterPrefabs.Length);
        int randPos = Random.Range(0, validPositions.Count);
        GameObject monster = Instantiate(monsterPrefabs[rand], validPositions[randPos], Quaternion.identity);
        MonsterStatHandler statHandler = monster.GetComponent<MonsterStatHandler>();
        statHandler.Init(DataManager.Instance.GetRandomMonsterData());
    }
}