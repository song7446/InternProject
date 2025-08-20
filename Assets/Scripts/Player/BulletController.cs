using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private LayerMask monsterMask;
    [SerializeField] private LayerMask wallMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & monsterMask) != 0)
        {
            collision.GetComponent<MonsterStatHandler>().OnDamaged.Invoke((int)GameManager.Instance.player.PlayerStatHandler.attack); 
            Destroy(gameObject);
        }
        else if (((1 << collision.gameObject.layer) & wallMask) != 0)
        {
            Destroy(gameObject);
        }
    }
}
