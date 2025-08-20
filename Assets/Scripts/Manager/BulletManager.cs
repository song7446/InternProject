using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    player,
    monster,
}

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    private GameObject playerBulletPrefab;
    private GameObject monsterBulletPrefab;

    public Stack<GameObject> playerBullets = new Stack<GameObject>();
    public Stack<GameObject> monsterBullets;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerBulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        monsterBulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet2");

        playerBullets = new Stack<GameObject>();
        monsterBullets = new Stack<GameObject>();
        
        CreateBullet();
    }

    public void CreateBullet()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject playerBullet = Instantiate(playerBulletPrefab, Vector2.zero, Quaternion.identity, transform);
            GameObject monsterBullet = Instantiate(monsterBulletPrefab, Vector2.zero, Quaternion.identity, transform);

            BulletController playerBulletController = playerBullet.GetComponent<BulletController>();
            BulletController monsterBulletController = monsterBullet.GetComponent<BulletController>();

            playerBulletController.bulletType = BulletType.player;
            monsterBulletController.bulletType = BulletType.monster;

            playerBullets.Push(playerBullet);
            monsterBullets.Push(monsterBullet);

            playerBullet.SetActive(false);
            monsterBullet.SetActive(false);
        }
    }

    public GameObject OnSpawnBullet(Transform pos, Quaternion rot, BulletType type)
    {
        GameObject bullet;
        if (type == BulletType.player)
        {
            if (playerBullets.Count > 0)
            {
                bullet = playerBullets.Pop();
                bullet.transform.position = pos.position;
                bullet.transform.rotation = rot;
            }
            else
                bullet = Instantiate(playerBulletPrefab, pos.position, rot, transform);
        }

        else
        {
            if (monsterBullets.Count > 0)
            {
                bullet = monsterBullets.Pop();
                bullet.transform.position = pos.position;
                bullet.transform.rotation = rot;
            }
            else
                bullet = Instantiate(monsterBulletPrefab, pos.position, rot, transform);
        }
        bullet.SetActive(true);
        return bullet;
    }

    public void OnDestroyBullet(GameObject bullet, BulletType type)
    {
        if (type == BulletType.player)
            playerBullets.Push(bullet);
        else
            monsterBullets.Push(bullet);

        bullet.SetActive(false);
    }
}