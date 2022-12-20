using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RootPlayerClasses
{
    public Vector3 _fireDir;

    private bool _isGetDamage;
    private float _invincibilityTime;
    private float _invincibilityTimer;
    private ProtectiveBallController _protectController;

    public override void Init()
    {
        _level = 1;
        _maxExp = _maxExps[_level];
        _maxHp = 100;

        _exp = 0;
        _hp = 100;
        _damage = 10;

        _isGetDamage = false;
        _invincibilityTime = 3;
        _invincibilityTimer = 0;
    }

    void SetClass<T>(ref T _class) where T : RootPlayerClasses
    {
        _class = GetComponent<T>();
        if(_class == null)
        {
            _class = gameObject.AddComponent<T>();
        }
        _class.Init();
    }

    void Awake()
    {
        SetClass<PlayerController>(ref _player);
        SetClass<PlayerMoveController>(ref _moveController);
        SetClass<PlayerUIController>(ref _uiController);
        SetClass<ProtectiveBallController>(ref _protectController);
    }

    void Update()
    {
        _moveController.Move();

        Invincibility();

        if (_moveDir != Vector3.zero)
            _fireDir = _moveDir;
    }

    public Vector3 GetFireDir()
    {
        return _fireDir;
    }

    public int GetDamage()
    {
        return _damage;
    }

    void Invincibility()
    {
        if (_isGetDamage)
        {
            _invincibilityTimer += Time.deltaTime;
            if (_invincibilityTimer >= _invincibilityTime)
            {
                _invincibilityTimer = 0;
                _protectController.CloseProtecter();
                _isGetDamage = false;
            }
        }
    }

    void Hit(int damage)
    {
        if (_isGetDamage)
            return;

        AudioManager.inst.PlayEff(0);
        ExplosionManager.inst.ShowExplosion(transform.position);
        _isGetDamage = true;
        _protectController.ShowProtecter();

        _hp -= damage;
        if (_hp <= 0)
        {
            _hp = 0;

            gameObject.SetActive(false);
            _moveSpeed = 0;
            _uiController.ShowEnd();
        }
        _uiController.SetHP();
    }

    private void OnCollisionStay(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Enemy":
                {
                    EnemyController enemy = collision.transform.GetComponent<EnemyController>();

                    Hit(enemy.GetDamage());
                    enemy.Hit(_damage);

                    break;
                }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "EXP":
                {
                    _exp += other.GetComponent<ExpController>().Contact();
                    _uiController.SetEXP();
                    AudioManager.inst.PlayEff(2);
                    break;
                }

            case "HP":
                {
                    other.gameObject.SetActive(false);

                    _hp += 10;
                    if (_hp > _maxHp)
                    {
                        _hp = _maxHp;
                    }
                    _uiController.SetHP();
                    break;
                }
        }
    }
}
