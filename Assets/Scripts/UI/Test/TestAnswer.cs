using System;
using LeitnerSystem;
using UnityEngine;
using UnityEngine.UI;

public abstract class TestAnswer : MonoBehaviour
{
    public Image Background;
    public bool IsSelected;

    public abstract void PopulateUI(LearnViewCanvas c, Answer a);
    public abstract Answer GetAnswer();
}