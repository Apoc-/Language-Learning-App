using System;
using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;

public class LearnViewCanvas : MonoBehaviour
{
    private LeitnerSession session;
    private List<Card> cards;

    public AudioSource AudioSource;

    public void PopulateUI(LeitnerSession session, List<Card> cards)
    {
        this.session = session;
        this.cards = cards;


    }

    public void ReturnButton()
    {
        if (ViewHandler.Instance.CurrentClass == UI.ClassType.Alphabet)
        {
            ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.None;
            ViewHandler.Instance.SwitchToView("Dictionary or Learning");
        }
        else
        {
            ViewHandler.Instance.CurrentCategory = null;
            ViewHandler.Instance.SwitchToView("Category");
        }
    }
}