using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetListRow : MonoBehaviour
{
    public AudioSource AudioSource;

    private AlphabetEntry data;
    
    public void PopulateUI(AlphabetEntry data)
    {
        this.data = data;

        name = data.Id;
        transform.Find("Character").GetComponent<Text>().text = data.Character;
    }

    public void PlayContextFreeAudio()
    {
        AudioSource.Stop();
        AudioSource.clip = data.ContextFreeAudio.Audio;
        AudioSource.Play();
    }

    public void PlayContextSensitiveAudio()
    {
        AudioSource.Stop();
        AudioSource.clip = data.ContextSensitiveAudio.Audio;
        AudioSource.Play();
    }

    public void PlayExampleWordAudio()
    {
        AudioSource.Stop();
        AudioSource.clip = data.ExampleWordAudio.Audio;
        AudioSource.Play();
    }
}
