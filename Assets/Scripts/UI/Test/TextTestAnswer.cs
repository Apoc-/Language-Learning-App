using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TextTestAnswer : TestAnswer
{
    public Text Text;

    private LearnViewCanvas canvas;
    private Answer answer;
    
    public override void PopulateUI(LearnViewCanvas canvas, Answer answer)
    {
        this.canvas = canvas;
        this.answer = answer;

        Text.text = answer.AsTextAnswer().Text;
    }
}
