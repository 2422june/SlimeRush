using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : RootPlayerClasses
{
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private Transform ScreenCanvas;
    [SerializeField]
    private Transform skillSelectPanel;
    [SerializeField]
    private Transform endPanel;

    private Slider _hpBar, _expBar;

    private bool _isGetExp;
    private float _expAddSpeed;

    public override void Init()
    {
        canvas = GameObject.Find("PlayerCanvas").transform;
        ScreenCanvas = GameObject.Find("ScreenCanvas").transform;
        skillSelectPanel = ScreenCanvas.Find("SkillSelectPanel");
        endPanel = ScreenCanvas.Find("GameOverPanel");

        _expBar = canvas.Find("EXP").GetComponent<Slider>();
        _hpBar = canvas.Find("HP").GetComponent<Slider>();

        SetFirstValue(_maxExp, _maxHp);

        _isGetExp = false;
    }

    public void ShowSkillSelect()
    {
        skillSelectPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ShowEnd()
    {
        endPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetFirstValue(int maxHp, int maxExp)
    {
        SetHpMax(maxHp);
        SetExpMax(maxExp);

        SetEXP();
        SetHP();
    }

    public void SetHpMax(int hp)
    {
        _maxHp = hp;
        _hpBar.maxValue = _maxHp;
    }

    public void SetExpMax(int exp)
    {
        _maxExp = exp;
        _expBar.maxValue = _maxExp;
    }

    public void LevelUp()
    {
        _level++;
        _expBar.value = 0;
        _exp -= _maxExp;
        SetExpMax(_maxExps[_level]);
        _uiController.ShowSkillSelect();
        SetEXP();
    }

    public void SetEXP()
    {
        _isGetExp = true;
        _expAddSpeed = (_exp - _expBar.value) * 5;
    }

    void Update()
    {
        if(_isGetExp)
        {
            if (_expBar.value < _exp)
            {
                _expBar.value += _expAddSpeed * Time.deltaTime;

                if(_expBar.value >= _maxExp)
                {
                    LevelUp();
                }
            }
            else
            {
                _expBar.value = _exp;
                _isGetExp = false;
            }
        }
        
    }

    public void SetHP()
    {
        if (_hp > _maxHp)
        {
            _hp = _maxHp;
        }
        _hpBar.value = _hp;
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
