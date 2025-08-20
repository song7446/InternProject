using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveController : MonoBehaviour
{
    private void Update()
    {
        GameManager.Instance.player.transform.position = transform.position;
    }
}
