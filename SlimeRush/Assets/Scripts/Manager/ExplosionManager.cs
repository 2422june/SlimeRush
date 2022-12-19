using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public static ExplosionManager inst = null;

    void Awake()
    {
        inst = this;
    }

    public void ShowExplosion(Vector3 pos)
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), pos, Quaternion.identity);
    }
}
