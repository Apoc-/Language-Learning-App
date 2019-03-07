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
        // setting Canvas background to white that will look good
        ChangeBackgroundColor(new Color32(0,0,0,0));
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
        // setting Canvas background to white that will look good
        ChangeBackgroundColor(new Color32(0,0,0,0));

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

        // setting Canvas background to white that will look good
        ChangeBackgroundColor(Color.white);
        var data = DataProvider.DataCache.Instance.GetDialoguesByCategory(currentCategoryId);
        // var dialogue = data.Entries;
        List<DialogueData> dialogue = new List<DialogueData>();


        foreach (var entry in data)
        {
            if (entry.Entries[Language.German].Count == entry.Entries[Language.Chinese].Count)
            {
                for (var i = 0; i < entry.Entries[Language.German].Count; i++)
                {
                    dialogue.Add(new DialogueData(entry.Entries[Language.German][i], entry.Entries[Language.Chinese][i]));

                }
            }
            bool speeker = true;
            foreach (var content in dialogue)
            {
                GameObject row = GameObject.Instantiate(DialogueRowPrefab, ListContainer.transform);
                var row2 = row.GetComponent<DialogueListRow>();
                row2.PopulateUI(content, speeker);
                speeker = !speeker;
            }
            // foreach (var content in entry.Entries[Language.German])
            // {  
            //     german.Add(content);
            // }  
            // foreach (var content in entry.Entries[Language.Chinese])
            // {  
            //     taiwan.Add(content);
            // }   
            // var C = german.Concat<DialogueEntry>(taiwan).ToList<DialogueEntry>();
            // foreach(var s in C){
            //     print(s.Text);
            // }


        }
        // GameObject row = GameObject.Instantiate(DialogueRowPrefab, ListContainer.transform);
        // var row2 = row.GetComponent<DialogueListRow>();
        // row2.PopulateUI(content);

    }
    private void ChangeBackgroundColor(Color color)
    {
        
        ListContainer.GetComponent<Image>().color = color;
    }

    private void LoadSayingData(string currentCategoryId)
    {
        throw new NotImplementedException();
        var data = DataProvider.DataCache.Instance.GetSayings();
    }

    public void ReturnButton()
    {
        // ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.None;
        ViewHandler.Instance.SwitchToView(ViewToReturnTo);
    }



}