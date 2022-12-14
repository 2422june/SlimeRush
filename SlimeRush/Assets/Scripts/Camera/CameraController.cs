using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _customDifference;    ///Difference between player position and camera position
    private Vector3 _difference;

    private Vector3 _moveDir;       ///Player movement direction
    private Vector3 _destination;   ///Camera's destination

    private Transform _player;      ///The player transform
    private JoystickController _joystick;

    void Awake()
    {
        _joystick = FindObjectOfType<JoystickController>();
        _player = GameObject.Find("Player").transform;

        _difference.y = 6;
        _difference.z = -3;

        if (_customDifference != Vector3.zero)
            _difference = _customDifference;
    }

    void Update()
    {
        _moveDir = _joystick.GetJoystickDir();
        SetDestination();

        /// move to the destination smoothly
        transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * 3f);
    }

    public void SetDestination()
    {
        _destination = _player.position + _moveDir + _difference;
    }
}
