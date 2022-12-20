using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst = null;

    private AudioSource eff;
    [SerializeField]
    private List<AudioClip> effs = new List<AudioClip>();

    private void Start()
    {
        inst = this;

        eff = gameObject.AddComponent<AudioSource>();
        effs.Add(Resources.Load<AudioClip>("boom"));
        effs.Add(Resources.Load<AudioClip>("click"));
        effs.Add(Resources.Load<AudioClip>("get"));
    }

    public void PlayEff(int index)
    {
        if (index >= effs.Count)
            return;

        eff.clip = effs[index];
        eff.Play();
    }
}
