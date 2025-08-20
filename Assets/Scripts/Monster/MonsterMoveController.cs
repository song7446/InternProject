using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveController : MonoBehaviour
{
    float stopDistance = 0.5f;
    
    MonsterStatHandler monsterStatHandler;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        monsterStatHandler = GetComponent<MonsterStatHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3  direction = GameManager.Instance.player.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance > stopDistance)
        {
            direction.Normalize();
            transform.position += direction * monsterStatHandler.monsterData.MoveSpeed * Time.deltaTime;
        }

        if (transform.position.x < GameManager.Instance.player.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
