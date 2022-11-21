using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _difference;    ///Difference between player position and camera position
    private Vector3 _moveDir;       ///Player movement direction
    private Vector3 _destination;   ///Camera's destination

    [SerializeField]
    private Transform _player;      ///The player transform

    void Update()
    {
        /// If the player is not move, the camera is can't move.
        if (_moveDir == Vector3.zero)
            transform.position = Vector3.Lerp(transform.position, _player.position + _difference, Time.deltaTime * 6f);

        /// move to the destination smoothly
        transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * 3f);
    }

    public void SetDestination(Vector3 moveDir)
    {
        /// get player movement direction
        _moveDir = moveDir;

        _destination = _player.position + _moveDir + _difference;
    }
}
