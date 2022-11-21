using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _different;
    private Vector3 _moveDir;
    private Vector3 _destination;
    [SerializeField]
    private Transform _player;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * 3f);
    }

    public void SetDestination(Vector3 moveDir)
    {
        _moveDir = moveDir;
        _destination = _moveDir + _player.position + _different;
    }
}
