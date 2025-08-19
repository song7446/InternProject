using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    void Start()
    {
        LoadMonsterData();
    }

    void LoadMonsterData()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Monster");

        if (json != null)
        {
            MonsterWrapper datas = JsonUtility.FromJson<MonsterWrapper>(json.text);
            MonsterData[] monsterDatas = datas.Monster;

            foreach (MonsterData data in monsterDatas)
            {
                Debug.Log(data.Name);
            }
        }
    }
}
