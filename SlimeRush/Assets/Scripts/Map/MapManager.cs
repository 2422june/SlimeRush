using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private Transform _mapParent;
    [SerializeField]
    private List<Transform> _mapTiles;

    private void Awake()
    {
        _mapParent = GameObject.Find("Grounds").transform;
    }
}
