using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{

    [SerializeField]
    public byte _type;

    public int Contact()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
        return Define.resultExps[_type];
    }
}
