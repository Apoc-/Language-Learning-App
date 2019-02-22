using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ViewHandler : MonoBehaviour
{
    public Header Header;
    public NavigationDrawer NavigationDrawer;

    #region VIEWS

    private View currentView;
    public View initialView;
    
    public View[] views;
    #endregion


    // Gloable variable to store data
    static public Dictionary<string, string> ViewMap = new Dictionary<string, string> {
      {"Class",null}, {"LearnOrDic",null}, {"Category",null},{"List",null}
    };
      

    private void Start()
    {

        views = GetComponentsInChildren<View>();
        currentView = GetViewByTitle("Category");
        SwitchToView(initialView);
    }

    private void SwitchToView(View targetView)
    {
        if (currentView == targetView) return;
        
        foreach (var view in views)
        {
            if (view == targetView)
            {
                view.gameObject.SetActive(true);
                Header.title.text = targetView.Title;
            }
            else
            {
                view.gameObject.SetActive(false);
            }
        }
        currentView = targetView;
    }

    public void AboutButtonPressed()
    {
        SwitchToView(GetViewByTitle("About"));
    }
    
    public void StartButtonPressed()
    {
        SwitchToView(GetViewByTitle("Start"));
    }




    public void LanguageSelect()
    {
        var language = EventSystem.current.currentSelectedGameObject.name;
        switch (language)
        {
            case "German":
                SwitchToView(GetViewByTitle("Class"));
                break;
            case "Chinese":
                SwitchToView(GetViewByTitle("Class"));
                break;

            default:
                Debug.Log("Language button select Error");
                break;
        }

    }


    public void ClassSelect()
    {
        var Class = EventSystem.current.currentSelectedGameObject.name;
        switch (Class)
        {
            case "Alphabet/Phonics":
                ViewMap["Class"] = "Alphabet/Phonics";
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "CategoryItem":
                ViewMap["Class"] = "CategoryItem";
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "Greeting":
                ViewMap["Class"] = "Greeting";
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "Saying":
                ViewMap["Class"] = "Saying";
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "ReturnButton":
                ViewMap["Class"] = null;
                SwitchToView(GetViewByTitle("LanguageCanvas"));
                break;
            default:
                Debug.Log("Class button select Error");
                break;

        }

    }

    public void DictionaryOrLearningOptions()
    {
        var selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {
            case "Learning":
                ViewMap["LearnOrDic"] = "Learning";
                // Into Learning Process
                break;
            case "Dictionary":
                ViewMap["LearnOrDic"] = "Dictionary";
                SwitchToView(GetViewByTitle("Category"));
                break;
            case "ReturnButton":
                ViewMap["LearnOrDic"] = null;
                SwitchToView(GetViewByTitle("Class"));
                break;

            default:
                Debug.Log("Dictionary or Learning button select Error");
                break;

        }

    }

    public void CategorySelect()
    {         
        var selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {

            case "ReturnButton":
                ViewMap["Category"] = null;
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;

            default:
                Debug.Log("Dictionary or Learning button select Error");
                break;

        }

    }
    private View GetViewByTitle(String title)
    {

        foreach (var view in views)
        {
            if (view.Title == title) return view;
        }

        throw new Exception("View " + title + " was not found");
    }
}
