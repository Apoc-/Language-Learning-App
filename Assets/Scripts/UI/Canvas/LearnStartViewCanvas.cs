using LeitnerSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LearnStartViewCanvas : MonoBehaviour
{
    public string ViewToReturnTo { get; set; }

    private void OnEnable()
    {

    }

    public void StartLearning(int questionAmount)
    {
        var session = LeitnerSession.CreateSession();
        List<Card> cards;

        switch (ViewHandler.Instance.CurrentClass)
        {
            case UI.ClassType.Alphabet:
                cards = session.GetAlphabetCards(questionAmount);
                break;

            case UI.ClassType.Vocabulary:
                cards = session.GetVocabCards(questionAmount);
                break;

            case UI.ClassType.Saying:
                cards = session.GetSayingCards(questionAmount);
                break;

            case UI.ClassType.Dialogue:
                throw new NotImplementedException("Test not yet implemented for class 'Dialogue'");
                break;

            default:
                throw new Exception("StartLearning was called without selecting a Class");
        }

        var view = ViewHandler.Instance.SwitchToView("LearnView");
        var learnView = view.GetComponent<LearnViewCanvas>();
        learnView.session = session;
        learnView.cards = cards;
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