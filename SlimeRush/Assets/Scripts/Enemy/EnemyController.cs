using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _nav;
    [SerializeField]
    private Transform _player;

    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _nav.SetDestination(_player.position);
    }
}
