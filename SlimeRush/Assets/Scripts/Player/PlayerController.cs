using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RootPlayerClasses
{
    public override void Init()
    {
        _level = 1;
        _maxExp = _maxExps[_level];
        _maxHp = 100;

        _exp = 0;
        _hp = 100;
        Debug.Log("Player");
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
    }

    void Update()
    {
        _moveController.Move();
    }

    void LevelUp()
    {
        while(_exp >= _maxExp)
        {
            _exp -= _maxExp;
            _level++;
            Debug.Log("level : "+_level);
            _uiController.LevelUp();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EXP"))
        {
            _exp += other.GetComponent<ExpController>().Contact();

            LevelUp();
            _uiController.SetEXP();
        }

        if (other.CompareTag("HP"))
        {
            other.gameObject.SetActive(false);

            _hp += 10;
            if (_hp > _maxHp)
            {
                _hp = _maxHp;
            }
            _uiController.SetHP();
        }
    }
}
