using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Model;
using System.Linq;
using UI;

public class ListView : MonoBehaviour
{
    public GameObject AlphabetRowPrefab;
    public GameObject VocabularyRowPrefab;
    public GameObject SayingRowPrefab;
    public GameObject DialogueRowPrefab;

    public GameObject ListContainer;

    public string ViewToReturnTo;

    private readonly Dictionary<Type, string> typePrefabs = new Dictionary<Type, string>
    {
        { typeof(AlphabetEntry), "ListRowAlphabet" },
        { typeof(Vocabulary), "ListRowVocabulary" },
        { typeof(Saying), "ListRowSaying" },
        { typeof(Dialogue), "ListRowDialogue" }
    };

    void OnEnable()
    {
        ResetList();

        var currentClass = ViewHandler.Instance.CurrentClass;
        var currentCategoryId = ViewHandler.Instance.CurrentCategory;

        switch (currentClass)
        {
            case ClassType.Alphabet:
                LoadAlphabetData();
                break;

            case ClassType.Vocabulary:
                LoadVocabularyData(currentCategoryId);
                break;

            case ClassType.Dialogue:
                LoadDialogueData(currentCategoryId);
                break;

            case ClassType.Saying:
                LoadSayingData(currentCategoryId);
                break;

            default:
                break;
        }
    }

    private void ResetList()
    {
        foreach (Transform child in ListContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void LoadAlphabetData()
    {
        var data = DataProvider.DataCache.Instance.GetAlphabet();

        foreach (var entry in data.Entries)
        {
            GameObject row = GameObject.Instantiate(AlphabetRowPrefab, ListContainer.transform);
            var row2 = row.GetComponent<AlphabetListRow>();
            row2.PopulateUI(entry);
        }
    }

    private void LoadVocabularyData(string currentCategoryId)
    {
        var data = DataProvider.DataCache.Instance.GetVocabularyByCategory(currentCategoryId);

        foreach (var entry in data)
        {
            GameObject row = GameObject.Instantiate(VocabularyRowPrefab, ListContainer.transform);
            var row2 = row.GetComponent<VocabularyListRow>();
            row2.PopulateUI(entry);
        }
    }

    private void LoadDialogueData(string currentCategoryId)
    {
        
        var data = DataProvider.DataCache.Instance.GetDialoguesByCategory(currentCategoryId);

        foreach (var entry in data)
        {

            GameObject row = GameObject.Instantiate(DialogueRowPrefab, ListContainer.transform);
            var row2 = row.GetComponent<DialogueListRow>();
            row2.PopulateUI(entry);
        }

    }

    private void LoadSayingData(string currentCategoryId)
    {
        throw new NotImplementedException();
        var data = DataProvider.DataCache.Instance.GetSayingsByCategory(currentCategoryId);
    }

    public void ReturnButton()
    {
        ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.None;
        ViewHandler.Instance.SwitchToView(ViewToReturnTo);
    }

    
    
}