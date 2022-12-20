using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{

    public List<string> _canSelectSkill = new List<string>();

    private Transform canvas;
    private Transform card;
    private Transform panel;
    private Text text;

    private void Start()
    {
        canvas = GameObject.Find("ScreenCanvas").transform;
        panel = canvas.Find("SkillSelectPanel");
        card = panel.Find("Card");
        text = card.GetComponentInChildren<Text>();

        _canSelectSkill.Clear();
        _canSelectSkill.Add("Ring");
        _canSelectSkill.Add("Bullet");
    }

    public void NewSkill()
    {
        if(_canSelectSkill.Count == 0)
        {
            Close();
        }
        else
        {
            int i = Random.Range(0, _canSelectSkill.Count - 1);
            text.text = _canSelectSkill[i];

            switch(_canSelectSkill[i])
            {
                case "Ring":
                    gameObject.AddComponent<RingBase>();
                    break;

                case "Bullet":
                    gameObject.AddComponent<BulletBase>();
                    break;
            }
            _canSelectSkill.RemoveAt(i);
        }
    }

    public void Close()
    {

        AudioManager.inst.PlayEff(1);
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
