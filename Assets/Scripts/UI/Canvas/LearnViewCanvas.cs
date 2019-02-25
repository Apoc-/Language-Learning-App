using System;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;

public class LearnViewCanvas : MonoBehaviour
{
    public LeitnerSession session;
    public List<Card> cards;

    private void OnEnable()
    {
        
    }

    public void ReturnButton()
    {
        if (ViewHandler.Instance.CurrentClass == UI.ClassType.Alphabet)
        {
            ViewHandler.Instance.CurrentClass = UI.ClassType.None;
            ViewHandler.Instance.SwitchToView("Class");
        }
        else
        {
            ViewHandler.Instance.CurrentCategory = null;
            ViewHandler.Instance.SwitchToView("Category");
        }
    }
}