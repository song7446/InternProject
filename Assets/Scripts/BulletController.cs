using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & mask) != 0)
        {
            Debug.Log(collision.gameObject.layer);
            Destroy(gameObject);       
        }
    }
}
