using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TextTestAnswer : TestAnswer
{
    public Text Text;

    private LearnViewCanvas canvas;
    private TextAnswer answer;

    public override void PopulateUI(LearnViewCanvas c, Answer a)
    {
        canvas = c;
        answer = a.AsTextAnswer();

        Text.text = answer.Text;
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
