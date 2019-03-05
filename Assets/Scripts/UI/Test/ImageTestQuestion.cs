using System.Collections;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public class ImageTestQuestion : TestQuestion
{
    public Text Text;
    public Image Image;

    private LearnViewCanvas canvas;
    private ImageQuestion question;

    public override void PopulateUI(LearnViewCanvas c, Question q)
    {
        canvas = c;
        question = q.AsImageQuestion();

        Image.sprite = question.Image;
    }

}
