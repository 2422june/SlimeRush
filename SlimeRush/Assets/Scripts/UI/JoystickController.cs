using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private Transform _base, _stick;
    private Vector3 _dir, _mousePosition;
    private float _swipeRange;

    void Start()
    {
        _base = transform.Find("Joystick");
        _stick = _base.Find("Stick");

        _swipeRange = 100;
        SetJoyskick(false);
    }

    void SetJoyskick(bool active)
    {
        _base.gameObject.SetActive(active);
        _stick.position = _base.position;
    }

    void RestrictSwipeRange()
    {
        if (Vector3.Distance(_mousePosition, _base.position) >= _swipeRange)
        {
            Vector3 betterSwipePos = (_mousePosition - _base.position).normalized * _swipeRange;
            _mousePosition = _base.position + betterSwipePos;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _base.position = Input.mousePosition;
            SetJoyskick(true);
        }

        if (Input.GetMouseButton(0))
        {
            _mousePosition = Input.mousePosition;

            RestrictSwipeRange();
            _stick.position = _mousePosition;
            
            _dir = _stick.localPosition.normalized;
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetJoyskick(false);
            _dir = Vector3.zero;
        }
    }

    public Vector3 GetJoystickDir()
    {
        return (Vector3.right * _dir.x) + (Vector3.forward * _dir.y);
    }
}
