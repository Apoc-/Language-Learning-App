using System;
using System.Collections.Generic;
using System.Linq;
using LeitnerSystem;
using UnityEngine;

public class LearnViewCanvas : MonoBehaviour
{
    private LeitnerSession session;
    private List<Card> cards;

    public GameObject QuestionContainer;
    public GameObject Answer1Container;
    public GameObject Answer2Container;
    public GameObject Answer3Container;

    public GameObject TextQuestionPrefab;
    public GameObject AudioQuestionPrefab;
    public GameObject ImageQuestionPrefab;

    public GameObject TextAnswerPrefab;
    public GameObject AudioAnswerPrefab;
    public GameObject ImageAnswerPrefab;

    public AudioSource AudioSource;

    public void PopulateUI(LeitnerSession session, List<Card> cards)
    {
        this.session = session;
        this.cards = cards;

        var c = cards.FirstOrDefault();
        if (c == null) throw new Exception("LeitnerSession returned 0 cards");

        GenerateUiCard(c);
    }

    private void GenerateUiCard(Card c)
    {
        ResetContainers();

        GameObject questionPrefab = GetQuestionPrefab(c);
        GameObject answerPrefab = GetAnswerPrefab(c);

        // create prefabs for all 4 question types and all 3 answer types

        var questionGo = Instantiate(questionPrefab, QuestionContainer.transform);
        var answer1Go = Instantiate(answerPrefab, Answer1Container.transform);
        var answer2Go = Instantiate(answerPrefab, Answer2Container.transform);
        var answer3Go = Instantiate(answerPrefab, Answer3Container.transform);

        var question = questionGo.GetComponent<TestQuestion>();
        var answer1 = answer1Go.GetComponent<TestAnswer>();
        var answer2 = answer2Go.GetComponent<TestAnswer>();
        var answer3 = answer3Go.GetComponent<TestAnswer>();

        question.PopulateUI(this, c.Question);
        answer1.PopulateUI(this, c.Answers[0]);
        answer2.PopulateUI(this, c.Answers[0]);
        answer3.PopulateUI(this, c.Answers[0]);
    }

    private void ResetContainers()
    {
        ResetGameObject(QuestionContainer);
        ResetGameObject(Answer1Container);
        ResetGameObject(Answer2Container);
        ResetGameObject(Answer3Container);
    }

    private void ResetGameObject(GameObject o)
    {
        foreach (Transform child in o.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private GameObject GetQuestionPrefab(Card c)
    {
        switch (c.CardFormat)
        {
            case CardFormat.ForeignAudioToLocalText:
            case CardFormat.ForeignAudioToForeignText:
                return AudioQuestionPrefab;

            case CardFormat.ImageToForeignText:
                return ImageQuestionPrefab;

            default:
                return TextQuestionPrefab;
        }
    }

    private GameObject GetAnswerPrefab(Card c)
    {
        switch (c.CardFormat)
        {
            case CardFormat.ForeignTextToForeignAudio:
            case CardFormat.LocalTextToForeignAudio:
                return AudioAnswerPrefab;

            case CardFormat.ForeignTextToImage:
                return ImageAnswerPrefab;

            default:
                return TextAnswerPrefab;
        }
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

    public void PlayAudio(AudioClip clip)
    {
        AudioSource.Stop();
        AudioSource.clip = clip;
        AudioSource.Play();
    }
}