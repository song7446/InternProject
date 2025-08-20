using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemData itemData;
    
    [SerializeField] private LayerMask playerMask;
    
    public void Init(ItemData itemData)
    {
        this.itemData = itemData;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerMask) != 0)
        {
            Debug.Log("Item Picked Up");
            Destroy(gameObject);
        }
    }
}
