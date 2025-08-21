using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInformationUI : MonoBehaviour
{
    [SerializeField] private GameObject rightPanel;
    [SerializeField] private GameObject leftPanel;

    private GameObject slotPrefab;

    public Action<string> OnClickSlotAction;
    
    [SerializeField] private Text monsterName;
    [SerializeField] private Text monsterDescription;
    [SerializeField] private Text monsterAttack;
    [SerializeField] private Text monsterAttackRange;
    [SerializeField] private Text monsterAttackSpeed;
    [SerializeField] private Text monsterMoveSpeed;
    [SerializeField] private Text monsterDropItem;

    // Start is called before the first frame update
    void Start()
    {
        slotPrefab = Resources.Load<GameObject>("Prefabs/MonsterSlot");
        CreateMonsterSlot();

        OnClickSlotAction += OnClickSlot;
    }

    void CreateMonsterSlot()
    {
        int monsterCount = DataManager.Instance.monsterDatas.Length;

        for (int i = 0; i < monsterCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, rightPanel.transform);
            slot.GetComponent<MonsterInformationSlotUI>().Init(DataManager.Instance.monsterDatas[i].Name, DataManager.Instance.monsterDatas[i].MonsterID);
        }
    }

    void OnClickSlot(string monsterId)
    {
        MonsterData monsterData = DataManager.Instance.GetMonsterDataFromId(monsterId);
        
        monsterName.text = monsterData.Name;
        monsterDescription.text = monsterData.Description;
        monsterAttack.text = monsterData.Attack.ToString();
        monsterAttackRange.text = monsterData.AttackRange.ToString();
        monsterAttackSpeed.text= monsterData.AttackSpeed.ToString();
        monsterMoveSpeed.text= monsterData.MoveSpeed.ToString();
        string[] dropItems = monsterData.DropItem.Split(',');
        string itemName = "";
        foreach (var dropItem in dropItems)
        {
            itemName += DataManager.Instance.GetItemDataFromId(int.Parse(dropItem.Trim())).Name + " ";
        }
        monsterDropItem.text = itemName;
    }
}