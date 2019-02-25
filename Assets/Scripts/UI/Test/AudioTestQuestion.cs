using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class AudioTestQuestion : TestQuestion
{
    public Text Text;

    private LearnViewCanvas canvas;
    private AudioQuestion question;

    public override void PopulateUI(LearnViewCanvas c, Question q)
    {
        canvas = c;
        question = q.AsAudioQuestion();
        canvas.PlayAudio(question.AudioClip);
    }

    public void OnClick()
    {
        canvas.PlayAudio(question.AudioClip);
    }

}
