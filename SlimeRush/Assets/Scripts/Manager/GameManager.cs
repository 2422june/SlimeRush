using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject .FindObjectOfType<GameManager>();
            }
            return _instance;
        }

        private set { }
    }

    public Action _awake;

    private void Awake()
    {
        //_awake.Invoke();
    }
}
