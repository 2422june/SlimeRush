using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 moveDir;
    private float moveSpeed;
    private int _damage;

    public void Init(Vector3 fireDir, int damage)
    {
        transform.LookAt(transform.position + fireDir);
        moveDir = fireDir;
        moveSpeed = 50;
        _damage = damage;
    }

    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Enemy":
                {
                    EnemyController enemy = collision.transform.GetComponent<EnemyController>();

                    enemy.Hit(_damage);

                    break;
                }
        }
    }
}
