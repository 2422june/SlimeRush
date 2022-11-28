using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _h, _v;
    private float _moveSpeed;
    private float _rotateSpeed;
    private Vector3 _moveDir;
    [SerializeField]
    private CameraController _cameraController;
    private PlayerStateUIController _playerUI;

    void Start()
    {
        _moveSpeed = 5f;

        _playerUI = GetComponent<PlayerStateUIController>();
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _moveDir.x = _h;
        _moveDir.z = _v;

        _cameraController.SetDestination(_moveDir);

        transform.position += _moveDir * _moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + _moveDir);
    }
}
