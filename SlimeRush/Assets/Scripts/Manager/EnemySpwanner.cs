using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanner : MonoBehaviour
{
    private Transform player;
    private int time;
    private int cnt;
    private int range;
    private Vector3 pos;
    private Quaternion rot;

    private WaitForSeconds one;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        one = new WaitForSeconds(1);
        rot = Quaternion.Euler(Vector3.left * 90);
        StartCoroutine(ShowExp());
    }

    IEnumerator ShowExp()
    {
        while (true)
        {
            time = Random.Range(5, 10);

            for (int i = 0; i < cnt; i++)
            {
                pos = (Random.insideUnitSphere.normalized * range) + player.position;
                pos.y = 0;
                Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), pos, rot);
            }

            for (int i = 0; i < time; i++)
                yield return one;

            cnt = Random.Range(5, 10);
            range = Random.Range(15, 30);
        }
    }
}

