using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : RootPlayerClasses
{
    private JoystickController _joystick;

    public override void Init()
    {
        _joystick = FindObjectOfType<JoystickController>();
        _moveSpeed = 5f;
    }

    public void Move()
    {
        SetMoveDir();
        Rotate();
        transform.position += _moveDir.normalized * _moveSpeed * Time.deltaTime;
    }

    void SetMoveDir()
    {
        _moveDir = _joystick.GetJoystickDir();
    }

    void Rotate()
    {
        transform.LookAt(transform.position + _moveDir);
    }

}
