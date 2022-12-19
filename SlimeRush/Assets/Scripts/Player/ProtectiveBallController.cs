using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveBallController : RootPlayerClasses
{
    private Transform _protector;
    private Material _material;
    private Color _nowColor;
    private bool _isFadeOut;
    private bool _isFading;

    public override void Init()
    {
        _isFading = false;
        _isFadeOut = true;

        _protector = transform.Find("ProtectiveBall");
        _material = _protector.GetComponent<MeshRenderer>().material;
        _nowColor = _material.color;

        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        while(true)
        {
            if (_isFading)
            {
                if (_isFadeOut)
                {
                    _nowColor.a += Time.deltaTime * 3;
                    if (_nowColor.a >= 1)
                    {
                        _nowColor.a = 1;
                        _isFadeOut = false;
                    }
                }
                else
                {
                    _nowColor.a -= Time.deltaTime * 3;
                    if (_nowColor.a <= 0)
                    {
                        _nowColor.a = 0;
                        _isFadeOut = true;
                    }
                }
                _material.color = _nowColor;
            }

            yield return null;
        }
    }

    public void ShowProtecter()
    {
        _isFading = true;
        _isFadeOut = false;
        _nowColor.a = 1;
        _material.color = _nowColor;
    }

    public void CloseProtecter()
    {
        _isFading = false;
        _isFadeOut = true;
        _nowColor.a = 0;
        _material.color = _nowColor;
    }
}
