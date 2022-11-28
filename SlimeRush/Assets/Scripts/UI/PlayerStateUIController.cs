using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUIController : MonoBehaviour
{
    [SerializeField]
    private Transform worldCanvas, screenCanvas;

    private Slider _hpBar, _expBar;
    private int _level;
    private int _maxExp;
    private int _maxHp;
    private int[] _maxExps = {50, 100, 150, 200};

    void Awake()
    {
        worldCanvas = GameObject.Find("PlayerCanvas").transform;
        screenCanvas = GameObject.Find("ScreenCanvas").transform;

        _expBar = worldCanvas.Find("EXP").GetComponent<Slider>();
        _hpBar = worldCanvas.Find("HP").GetComponent<Slider>();

        _level = 0;
    }

    public void SetHpMax(out int hp)
    {
        hp = _maxHp;
    }

    public void SetExpMax(out int exp)
    {
        exp = _maxExp;
    }

    public void LevelUp()
    {
        _level++;
        _expBar.maxValue = _maxExps[_level];
    }

    public void SetEXP(int exp)
    {
        _expBar.value = exp;
    }

    public void SetHP(int hp)
    {
        if(hp > _maxHp)
        {
            hp = _maxHp;
        }
        _hpBar.value = hp;
    }
}
