using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private JoystickController stick;
    private float timer;
    private float coolTime;
    private Vector3 fireDir;
    private GameObject bullet;
    private GameObject product;
    private PlayerController player;
    private int damage;

    void Start()
    {
        player = GetComponent<PlayerController>();
        damage = player.GetDamage();

        bullet = Resources.Load<GameObject>("Prefabs/Bullet");

        coolTime = 3;
    }

    void Update()
    {
        fireDir = player.GetFireDir();
        Debug.Log(fireDir);

        timer += Time.deltaTime;

        if (timer >= coolTime)
        {
            timer = 0;
            product = Instantiate(bullet, transform.position + (Vector3.up*0.5f), Quaternion.identity);
            product.GetComponent<BulletController>().Init(fireDir, damage);
        }
    }
}
