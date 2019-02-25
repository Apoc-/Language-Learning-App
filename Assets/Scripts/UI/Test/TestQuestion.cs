using System;
using LeitnerSystem;
using UnityEngine;

public abstract class TestQuestion : MonoBehaviour
{
    public abstract void PopulateUI(LearnViewCanvas c, Question q);
}