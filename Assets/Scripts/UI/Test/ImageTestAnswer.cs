using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class ImageTestAnswer : TestAnswer
{
    public Image Image;

    private LearnViewCanvas canvas;
    private ImageAnswer answer;

    public override void PopulateUI(LearnViewCanvas c, Answer a)
    {
        canvas = c;
        answer = a.AsImageAnswer();

        Image.sprite = answer.Image;
    }

    public void OnClick()
    {
        canvas.SelectAnswer(this);
    }

    public override Answer GetAnswer()
    {
        return answer;
    }
}
