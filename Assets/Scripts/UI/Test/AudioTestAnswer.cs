using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class AudioTestAnswer : TestAnswer
{
    private LearnViewCanvas canvas;
    private AudioAnswer answer;

    public override void PopulateUI(LearnViewCanvas c, Answer a)
    {
        canvas = c;
        answer = a.AsAudioAnswer();
    }

    public void OnClick()
    {
        canvas.PlayAudio(answer.AudioClip);
        canvas.SelectAnswer(this);
    }

    public override Answer GetAnswer()
    {
        return answer;
    }
}
