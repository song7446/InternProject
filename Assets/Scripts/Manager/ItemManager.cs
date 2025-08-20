using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    private GameObject itemPrefab;

    private Stack<GameObject> itemPool = new Stack<GameObject>();

    private void Awake()
    {
        Instance = this;

        itemPrefab = Resources.Load<GameObject>("Prefabs/Item");
    }

    private void Start()
    {
        CreateItem();
    }

    public void CreateItem()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject item = Instantiate(itemPrefab, new Vector2(0, 0), Quaternion.identity, transform);
            item.SetActive(false);
            itemPool.Push(item);
        }
    }

    public void RecycleItem(int itemId, Vector2 pos)
    {
        ItemData itemData = DataManager.Instance.GetItemDataFromId(itemId);
        GameObject item;

        if (itemPool.Count > 0)
        {
            item = itemPool.Pop();
            item.transform.position = pos;
        }
        else
            item = Instantiate(itemPrefab, pos, Quaternion.identity, transform);
        
        Item itemScript = item.GetComponent<Item>();
        itemScript.Init(itemData);

        item.SetActive(true);
    }

    public void OnDestroyItem(GameObject item)
    {
        item.SetActive(false);
        itemPool.Push(item);
    }
}