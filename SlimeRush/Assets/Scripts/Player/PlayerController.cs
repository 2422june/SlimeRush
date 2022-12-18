using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _h, _v;
    private float _moveSpeed;
    private float _rotateSpeed;
    private Vector3 _moveDir;

    private int _exp;
    private int _hp;
    private int _maxHp;
    private int _maxExp;

    [SerializeField]
    private CameraController _cameraController;
    private PlayerStateUIController _playerUI;

    void Start()
    {
        _playerUI = GetComponent<PlayerStateUIController>();
        _cameraController = GameObject.FindObjectOfType<CameraController>();

        _moveSpeed = 5f;

        _exp = 0;
        _hp = 100;

        _playerUI.SetExpMax(_maxExp);
        _playerUI.SetHpMax(_maxHp);
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        Move();
        Rotate();
    }

    void Move()
    {
        _moveDir.x = _h;
        _moveDir.z = _v;

        transform.position += _moveDir.normalized * _moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        _cameraController.SetDestination(_moveDir);
        transform.LookAt(transform.position + _moveDir);
    }

    void LevelUp()
    {
        _exp = 0;
        _playerUI.LevelUp();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EXP"))
        {
            other.gameObject.SetActive(false);

            _exp += 10;
            if(_exp >= _maxExp)
            {
                LevelUp();
            }
            _playerUI.SetEXP(_exp);
        }

        if (other.CompareTag("HP"))
        {
            other.gameObject.SetActive(false);

            _hp += 10;
            if (_hp > _maxHp)
            {
                _hp = _maxHp;
            }
            _playerUI.SetHP(_hp);
        }
    }
}
