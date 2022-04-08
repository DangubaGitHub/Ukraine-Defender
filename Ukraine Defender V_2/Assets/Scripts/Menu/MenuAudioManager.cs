using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{

    public static MenuAudioManager instance;
    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(int sounds)
    {
        sfx[sounds].Play();
    }
}
