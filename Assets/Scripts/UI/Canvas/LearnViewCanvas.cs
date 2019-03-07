using System;
using System.Collections.Generic;
using System.Linq;
using LeitnerSystem;
using UnityEngine;

public class LearnViewCanvas : MonoBehaviour
{
    private LeitnerSession session;
    private List<Card> cards;
    private Card currentCard;
    private List<TestAnswer> currentAnswers = new List<TestAnswer>();

    public Color SelectedAnswerBackgroundColor;
    public Color DefaultAnswerBackgroundColor;
    public Color AnswerCorrectColor;
    public Color AnswerWrongColor;

    public GameObject QuestionContainer;
    public GameObject Answer1Container;
    public GameObject Answer2Container;
    public GameObject Answer3Container;
    public GameObject ConfirmButton;

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
        currentCard = c;
        currentAnswers = new List<TestAnswer>();
        ResetUI();

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

        currentAnswers.Add(answer1);
        currentAnswers.Add(answer2);
        currentAnswers.Add(answer3);

        question.PopulateUI(this, c.Question);
        answer1.PopulateUI(this, c.Answers[0]);
        answer2.PopulateUI(this, c.Answers[1]);
        answer3.PopulateUI(this, c.Answers[2]);
    }

    private void ResetUI()
    {
        ConfirmButton.SetActive(false);

        DestroyAllChildren(QuestionContainer);
        DestroyAllChildren(Answer1Container);
        DestroyAllChildren(Answer2Container);
        DestroyAllChildren(Answer3Container);
    }

    private void DestroyAllChildren(GameObject o)
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
        Gamification.GamificationManager.Instance.DisableProgressBar();

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
    
    public void SelectAnswer(TestAnswer testAnswer)
    {
        if (ConfirmButton.transform.Find("Content 2").gameObject.activeSelf) return;

        currentAnswers.ForEach(a =>
        {
            if (a == testAnswer)
            {
                a.IsSelected = true;
                a.Background.color = SelectedAnswerBackgroundColor;
            }
            else
            {
                a.IsSelected = false;
                a.Background.color = DefaultAnswerBackgroundColor;
            }
        });

        ConfirmButton.SetActive(true);
    }

    public void ConfirmAnswer()
    {
        if (currentCard == null)
        {
            NextQuestion();
            return;
        }

        TestAnswer selectedAnswer = currentAnswers.FirstOrDefault(ta => ta.IsSelected);
        var correct = currentCard.AnswerWith(selectedAnswer.GetAnswer());

        if (correct)
        {
            selectedAnswer.Background.color = AnswerCorrectColor;
        }
        else
        {
            var correctAnswer = currentAnswers.FirstOrDefault(ta => ta.GetAnswer().IsCorrectAnswer());
            correctAnswer.Background.color = AnswerCorrectColor;
            selectedAnswer.Background.color = AnswerWrongColor;
        }

        cards.Remove(currentCard);
        currentCard = null;
    }

    public void NextQuestion()
    {
        var nextCard = cards.FirstOrDefault();
        if (nextCard == null)
        {
            EndTest();
            return;
        }

        GenerateUiCard(nextCard);
    }

    private void EndTest()
    {
        Gamification.GamificationManager.Instance.DisableProgressBar();

        session.FinishSession();
        ViewHandler.Instance.SwitchToView("LearnStartView");
    }

    public void PlayAudio(AudioClip clip)
    {
        AudioSource.Stop();
        AudioSource.clip = clip;
        AudioSource.Play();
    }
}