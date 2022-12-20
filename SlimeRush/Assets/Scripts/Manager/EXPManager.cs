using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPManager : MonoBehaviour
{
    private Transform player;
    private int time;
    private int cnt;
    private int range;
    private int type;
    private Vector3 pos;
    private Quaternion rot;
    private GameObject product;

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
        while(true)
        {
            time = Random.Range(5, 10);

            for (int i = 0; i < cnt; i++)
            {
                pos = (Random.insideUnitSphere * range) + player.position;
                pos.y = 0.5f;
                product = Instantiate(Resources.Load<GameObject>("Prefabs/ExpObj"), pos, rot);
                product.GetComponent<ExpController>()._type = (byte)Random.Range(1, 3);
            }

            for(int i = 0; i < time; i++)
                yield return one;

            cnt = Random.Range(1, 5);
            range = Random.Range(3, 5);
        }
    }
}
