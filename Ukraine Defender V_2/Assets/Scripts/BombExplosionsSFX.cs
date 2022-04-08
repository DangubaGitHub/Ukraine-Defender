using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionsSFX : MonoBehaviour
{

    [SerializeField] List<AudioClip> audioClips;
    AudioClip currentClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float minWaitBetweenPlays;
    [SerializeField] float maxWaitBetweenPlays;
    [SerializeField] float waitTimeCountdow;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            if(waitTimeCountdow < 0)
            {
                currentClip = audioClips[Random.Range(0, audioClips.Count)];
                audioSource.clip = currentClip;
                audioSource.Play();
                waitTimeCountdow = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdow -= Time.deltaTime;
            }
        }
    }
}
