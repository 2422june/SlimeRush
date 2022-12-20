using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    private float rotSpeed = 180f;
    private int _damage;
    private Transform _player;
    private RingStonController[] _ston = new RingStonController[4];

    public void Init(int damage, Transform player)
    {
        _damage = damage;
        _player = player;

        for(int i = 1; i <= 4; i++)
        {
            _ston[i-1] = transform.Find("CoinSilver" + i).GetComponent<RingStonController>();
            _ston[i - 1].Init(_damage);
        }

    }

    void Update()
    {
        transform.position = _player.position;
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        Debug.Log("aa");
    }
}
