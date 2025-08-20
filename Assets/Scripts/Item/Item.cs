using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    ItemData itemData;
    
    [SerializeField] private LayerMask playerMask;
    
    [SerializeField] private Canvas canvas;
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemDescription;

    private float detectionRange = 4f;

    private void Update()
    {
        DetectPlayer();
    }

    public void Init(ItemData itemData)
    {
        this.itemData = itemData;
        itemName.text = itemData.Name;
        itemDescription.text = itemData.Description;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerMask) != 0)
        {
            GameManager.Instance.player.PlayerStatHandler.OnItemPickedUp.Invoke(itemData);
            ItemManager.Instance.OnDestroyItem(gameObject);
        }
    }
    
    
    private void DetectPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRange, playerMask);

        if (hits.Length > 0)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
