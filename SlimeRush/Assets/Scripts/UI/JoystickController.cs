using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private Transform _base, _stick;
    private Vector3 _dir, _mousePosition;
    private bool _isClick;
    private float _swipeRange;

    void Start()
    {
        _swipeRange = 100;
        _isClick = false;
        _base = transform.Find("Joystick");
        _stick = _base.Find("Stick");
        ShowJoyskick(false);
    }

    void ShowJoyskick(bool active)
    {
        _base.gameObject.SetActive(active);
    }

    void Update()
    {
        if (_isClick)
        {
            if (Input.GetMouseButton(0))
            {
                _mousePosition = Input.mousePosition;
                if(Vector3.Distance(_mousePosition, _base.position) >= _swipeRange)
                {
                    _mousePosition = _base.position + (_mousePosition - _base.position).normalized * _swipeRange;
                }
                _stick.position = _mousePosition;
                _dir = _stick.localPosition.normalized;
                Debug.Log(_dir);
            }
            else
            {
                _stick.position = _base.position;
                _isClick = false;
                ShowJoyskick(false);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShowJoyskick(true);
                _base.position = Input.mousePosition;
                _isClick = true;
            }
        }
    }
}
