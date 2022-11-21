using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform _followTarget;

    void Update()
    {
        transform.position = _followTarget.position;
    }
}
