using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Model;

public class ListView : MonoBehaviour
{
    public GameObject AlphabetRowPrefab;
    public GameObject VocabularyRowPrefab;
    public GameObject SayingRowPrefab;
    public GameObject DialogueRowPrefab;

    public List<Vocabulary> CellData = new List<Vocabulary>();

    private readonly Dictionary<Type, string> typePrefabs = new Dictionary<Type, string>
    {
        { typeof(AlphabetEntry), "ListRowAlphabet" },
        { typeof(Vocabulary), "ListRowVocabulary" },
        { typeof(Saying), "ListRowSaying" },
        { typeof(Dialogue), "ListRowDialogue" }
    };

    void Start()
    {
        var currentClass = ViewHandler.Instance.CurrentClass;
        var currentCategoryId = ViewHandler.Instance.CurrentCategory;

        switch (currentClass)
        {
            case ViewHandler.ClassType.Alphabet:
                LoadAlphabetData();
                break;

            case ViewHandler.ClassType.Vocabulary:
                LoadVocabularyData(currentCategoryId);
                break;

            case ViewHandler.ClassType.Dialogue:
                LoadDialogueData(currentCategoryId);
                break;

            case ViewHandler.ClassType.Saying:
                LoadSayingData(currentCategoryId);
                break;

            default:
                break;
        }
    }

    private void LoadAlphabetData()
    {
        throw new NotImplementedException();
        var data = DataProvider.DataProvider.Instance.GetAlphabet();
    }

    private void LoadVocabularyData(string currentCategoryId)
    {
        var data = DataProvider.DataProvider.Instance.GetVocabularyByCategory(currentCategoryId);

        foreach (var entry in data)
        {
            GameObject table = GameObject.Find("List/GridElements");
            GameObject row = GameObject.Instantiate(VocabularyRowPrefab, table.transform.position, table.transform.rotation) as GameObject;

            row.name = entry.Id;
            row.transform.SetParent(table.transform);
            row.transform.Find("Chinese").GetComponent<Text>().text = entry.Translation[Language.Chinese];
            row.transform.Find("German").GetComponent<Text>().text = entry.Translation[Language.German];
        }
    }

    private void LoadDialogueData(string currentCategoryId)
    {
        throw new NotImplementedException();
        var data = DataProvider.DataProvider.Instance.GetDialoguesByCategory(currentCategoryId);
    }

    private void LoadSayingData(string currentCategoryId)
    {
        throw new NotImplementedException();
        var data = DataProvider.DataProvider.Instance.GetSayingsByCategory(currentCategoryId);
    }
    
    public void ReturnButton()
    {
        Debug.Log("Close ListView");
        ViewHandler.Instance.SwitchToView("Category");
        Destroy(transform.parent.gameObject);
    }

    public class Vocabulary
    {
        public string German;
        public string Chinese;

        public Vocabulary(string newGerman, string newChinese)
        {
            German = newGerman;
            Chinese = newChinese;
        }
    }
}