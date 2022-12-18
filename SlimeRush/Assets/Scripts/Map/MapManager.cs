using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _mapTiles;

    private void Awake()
    {
        for(int i = 1; i <= 25; i++)
        {
            _mapTiles.Add(transform.Find($"Ground{i}"));
        }
    }
}
