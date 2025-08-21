using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInformationSlotUI : MonoBehaviour
{
    private Text monsterName;
    private string monsterInfoindex;
    private Button button;

    private void Awake()
    {
        monsterName = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        
        button.onClick.AddListener(OnClickMonsterSlot);
    }

    public void Init(string text, string monsterID)
    {
        monsterName.text = text;
        monsterInfoindex = monsterID;
    }

    void OnClickMonsterSlot()
    {
        UIManager.Instance.monsterInformationUI.OnClickSlotAction(monsterInfoindex);
    }
}
