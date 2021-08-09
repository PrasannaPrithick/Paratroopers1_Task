using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;
    public AudioClip fireSound;
    public AudioClip helicopterSound;
    public AudioSource helicopterAudioSource;
    public AudioSource sfx_AudioSource;
    public AudioClip soldierOpenedParachute;
    public AudioClip soldierLanded;
    public AudioClip playerDestroyed;
    public AudioClip soldierKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SoldierKilled()
    {
        sfx_AudioSource.clip = soldierKilled;
        sfx_AudioSource.Play();
    }

    public void PlayerGotDestroyed() 
    {
        sfx_AudioSource.clip = playerDestroyed;
        sfx_AudioSource.Play();
    }

    public void SoldierOpenedParachute() 
    {
        sfx_AudioSource.clip = soldierOpenedParachute;
        sfx_AudioSource.Play();
    }

    public void SoldierLanded()
    {
        sfx_AudioSource.clip = soldierLanded;
        sfx_AudioSource.Play();
    }

    public void FireSoundPlayOnce() 
    {
        sfx_AudioSource.clip = fireSound;
        sfx_AudioSource.Play();
    }

    public void HelicopterSound()
    {
        helicopterAudioSource.clip = helicopterSound;
        helicopterAudioSource.Play();
    }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

}
