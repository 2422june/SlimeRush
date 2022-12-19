using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [System.Serializable]
    public struct Skill
    {
        public float time;
        public float coolTime;
        public GameObject prefab;
    }

    public Skill skill;
}
