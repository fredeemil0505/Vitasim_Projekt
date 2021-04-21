using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource effectsounds;

    public AudioClip winSound;
    public AudioClip loseSound;

    static AudioClip winStandin;
    static AudioClip loseStandin;
    static AudioSource standInSource;
    
    private void Awake()
    {
        Debug.Log("hey");
        standInSource = effectsounds;
        winStandin = winSound;
        loseStandin = loseSound;

    }
    //plays a win/lose clip
    public void PlayAudioClip(bool winlose)
    {
        if (winlose == true)
        {
            standInSource.clip = winStandin;
            standInSource.Play();
        }
        else
        {
            standInSource.clip = loseSound;
            standInSource.Play();
        }
    }
}
