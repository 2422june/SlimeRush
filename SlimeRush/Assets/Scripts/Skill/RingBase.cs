using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBase : MonoBehaviour
{
    private float timer;
    private float time = 5;
    private float coolTime = 5;
    private bool isUse;
    private bool isReady = true;
    private int damage;
    private PlayerController player;

    private GameObject ring;
    private void Start()
    {
        player = GetComponent<PlayerController>();
        damage = player.GetDamage();
        ring = Instantiate(Resources.Load<GameObject>("Prefabs/Ring"), player.transform.position, Quaternion.identity);
        ring.GetComponent<RingController>().Init(damage, transform);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(isReady)
        {
            if(timer >= coolTime)
            {
                timer = 0;
                isReady = false;
                isUse = true;
                ring.SetActive(true);
            }
        }
        else if (isUse)
        {
            if (timer >= time)
            {
                timer = 0;
                isReady = true;
                isUse = false;
                ring.SetActive(false);
            }
        }
    }
}
