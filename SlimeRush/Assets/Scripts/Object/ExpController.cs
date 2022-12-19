using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{

    [SerializeField]
    private byte _type;

    public int Contact()
    {
        gameObject.SetActive(false);
        return Define.resultExps[_type];
    }
}
