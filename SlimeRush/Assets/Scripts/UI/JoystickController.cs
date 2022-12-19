using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private Transform _base, _stick;
    private Vector3 _dir, _mousePosition;
    private float _swipeRange;
    private bool _isShow;

    void Start()
    {
        _base = transform.Find("Joystick");
        _stick = _base.Find("Stick");

        _isShow = false;
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
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            _base.position = Input.mousePosition;
            SetJoyskick(true);
            _isShow = true;
        }

        if (!_isShow)
            return;

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
            _isShow = false;
        }
    }

    public Vector3 GetJoystickDir()
    {
        return (Vector3.right * _dir.x) + (Vector3.forward * _dir.y);
    }
}
