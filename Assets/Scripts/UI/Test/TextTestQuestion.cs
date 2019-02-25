using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TextTestQuestion : TestQuestion
{
    public Text Text;

    private LearnViewCanvas canvas;
    private TextQuestion question;

    public override void PopulateUI(LearnViewCanvas c, Question q)
    {
        canvas = c;
        question = q.AsTextQuestion();

        Text.text = q.AsTextQuestion().Text;
    }
}
