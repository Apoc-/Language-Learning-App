using System;
using LeitnerSystem;
using UnityEngine;

public abstract class TestAnswer : MonoBehaviour
{
    public abstract void PopulateUI(LearnViewCanvas canvas, Answer answer);
}