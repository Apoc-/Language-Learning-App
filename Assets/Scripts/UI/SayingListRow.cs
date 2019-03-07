using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class SayingListRow : MonoBehaviour
{
    public AudioSource AudioSource;
    public Text local;
    public Text foreign;

    private Saying data;
    
    public void PopulateUI(Saying data)
    {
        this.data = data;

        local.text = data.Text;
        foreign.text = data.Meaning;
    }

    public void PlayAudio()
    {
        AudioSource.Stop();
        AudioSource.clip = data.Audio.Audio;
        AudioSource.Play();
    }
}
