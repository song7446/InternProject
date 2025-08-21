using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public MonsterInformationUI monsterInformationUI;

    [SerializeField] private Button monsterInfoMationBtn;    
    [SerializeField] private Image gameOverImage;
    private void Awake()
    {
        Instance = this;
        
        monsterInfoMationBtn.onClick.AddListener(OnClickMonsterInfoBtn);
    }

    private void OnClickMonsterInfoBtn()
    {
        monsterInformationUI.gameObject.SetActive(true);
    }

    public void GameOverUI()
    {
        gameOverImage.gameObject.SetActive(true);
    }
}
