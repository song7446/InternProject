using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    
    [SerializeField] private GameObject itemPrefab;

    private void Awake()
    {
        Instance = this;
    }
    
    public void CreateItem(int itemId, Vector2 pos)
    {
        ItemData itemData = DataManager.Instance.GetItemDataFromId(itemId);
        GameObject item = Instantiate(itemPrefab, pos, Quaternion.identity);
        
        Item itemScript = item.GetComponent<Item>();
        itemScript.Init(itemData);
    }
}
