using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPlayerClasses : MonoBehaviour
{
    protected static PlayerController _player;
    protected static PlayerUIController _uiController;
    protected static PlayerMoveController _moveController;

    protected static int _level;
    protected static int[] _maxExps = { 0, 150, 200, 250, 300 };
    protected static int _maxHp;
    protected static int _maxExp;
    protected static int _exp;
    protected static int _hp;
    protected static int _damage;

    protected static float _moveSpeed;
    protected static Vector3 _moveDir;

    public virtual void Init()
    {

    }
}
