using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUIController : MonoBehaviour
{
    [SerializeField]
    private Transform worldCanvas, screenCanvas;

    private Slider _hpBar, _expBar;

    void Awake()
    {
        worldCanvas = GameObject.Find("PlayerCanvas").transform;
        screenCanvas = GameObject.Find("ScreenCanvas").transform;

        _expBar = worldCanvas.Find("EXP").GetComponent<Slider>();
        _hpBar = worldCanvas.Find("HP").GetComponent<Slider>();
    }

    public void SetEXP()
    {

    }

    public void SetHP()
    {

    }
}
