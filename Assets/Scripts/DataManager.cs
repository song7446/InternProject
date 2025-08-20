using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    MonsterData[] monsterDatas; 
    ItemData[] itemDatas;
    
    void Awake()
    {
        Instance = this;
        LoadMonsterData();
        LoadItemData();
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
    
    void LoadItemData()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Item");
        
        if (json != null)
        {
            ItemDataWrapper datas = JsonUtility.FromJson<ItemDataWrapper>(json.text);
            itemDatas = datas.Item;

            foreach (ItemData data in itemDatas)
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
    
    public ItemData GetItemDataFromId(int itemID)
    {
        foreach (ItemData data in itemDatas)
        {
            if (data.ItemID == itemID)
            {
                return data;
            }       
        }
        return null;
    }

    public ItemData GetRandomItemData()
    {
        int randomIndex = Random.Range(0, itemDatas.Length);
        return itemDatas[randomIndex];
    }
}
