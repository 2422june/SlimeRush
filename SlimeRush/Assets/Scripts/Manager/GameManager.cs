using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public Action _awake;

    private void Awake()
    {
        _instance = this;
    }
}
