using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    MonsterData[] monsterDatas; 
    void Awake()
    {
        Instance = this;
        LoadMonsterData();
    }

    void LoadMonsterData()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Monster");

        if (json != null)
        {
            MonsterWrapper datas = JsonUtility.FromJson<MonsterWrapper>(json.text);
            monsterDatas = datas.Monster;

            foreach (MonsterData data in monsterDatas)
            {
                Debug.Log(data.Name);
            }
        }
    }
    
    public MonsterData GetMonsterDataFromId(string monsterID)
    {
        foreach (MonsterData data in monsterDatas)
        {
            if (data.MonsterID == monsterID)
            {
                return data;
            }       
        }
        return null;
    }

    public MonsterData GetRandomMonsterData()
    {
        int randomIndex = Random.Range(0, monsterDatas.Length);
        return monsterDatas[randomIndex];
    }
}
