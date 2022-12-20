using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingStonController : MonoBehaviour
{
    private int _damage;

    public void Init(int damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.transform.GetComponent<EnemyController>();

            enemy.Hit(_damage);
        }
    }
}
