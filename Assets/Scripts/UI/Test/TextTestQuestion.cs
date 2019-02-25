using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TextTestQuestion : TestQuestion
{
    public Text Text;

    private LearnViewCanvas canvas;
    private Question question;

    public override void PopulateUI(LearnViewCanvas canvas, Question question)
    {
        this.canvas = canvas;
        this.question = question;

        Text.text = question.AsTextQuestion().Text;
    }

}
