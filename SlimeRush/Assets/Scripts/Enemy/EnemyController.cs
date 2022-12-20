using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _nav;
    [SerializeField]
    private Transform _player;
    private int _hp;
    private int _damage;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _nav = GetComponent<NavMeshAgent>();
        _damage = 10;
        _hp = 10;
    }

    void Update()
    {
        _nav.SetDestination(_player.position);
    }

    public void Hit(int damage)
    {

        AudioManager.inst.PlayEff(0);
        ExplosionManager.inst.ShowExplosion(transform.position);
        _hp -= damage;
        if(_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return _damage;
    }
}
