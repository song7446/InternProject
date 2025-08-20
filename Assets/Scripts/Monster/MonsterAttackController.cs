using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackController : BaseAttackController
{
    MonsterStatHandler monsterStatHandler;

    [SerializeField] private GameObject weapon;
    
    protected void Start()
    {
        monsterStatHandler = GetComponent<MonsterStatHandler>();

        fireTimer = monsterStatHandler.monsterData.AttackSpeed;
        fireDelay = monsterStatHandler.monsterData.AttackSpeed;
        detectionRange = monsterStatHandler.monsterData.AttackRange;
        enemies = new List<Transform>();
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet2");

        WeaponController weaponController = weapon.GetComponent<WeaponController>();
        weaponController.SetDamage(monsterStatHandler.GetDamageStat());;
    }
    
    protected override void DetectEmeny()
    {
        enemies.Clear();
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);

        if (hits.Length > 0)
        {
            foreach (var enemy in hits)
            {
                enemies.Add(enemy.transform);
            } 
        }
    }

    protected override void AutoAttack()
    {
        if (detectionRange > 2)
        {
            Vector2 direction = enemies[0].position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rigidbody = bullet.transform.GetComponent<Rigidbody2D>();
            rigidbody.velocity = direction.normalized * 5f;

            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.SetDamage(monsterStatHandler.GetDamageStat());
        }
        else
        {
            weapon.gameObject.SetActive(true);
        }
    }
}
