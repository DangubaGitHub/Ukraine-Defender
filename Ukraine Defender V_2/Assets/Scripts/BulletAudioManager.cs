using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAudioManager : MonoBehaviour
{

    public static BulletAudioManager instance;

    public AudioSource[] bulletSoundEffects;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBulletSFX(int soundToPlay)
    {
        bulletSoundEffects[soundToPlay].Play();
    }

}
