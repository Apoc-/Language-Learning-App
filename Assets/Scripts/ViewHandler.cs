using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHandler : MonoBehaviour
{
    public Header Header;
    public NavigationDrawer NavigationDrawer;

    #region VIEWS

    private View currentView;
    public View initialView;
    public Dictionary<String,GameObject> views;

    #endregion
    private void Awake()
    {
        views = new Dictionary<String, GameObject>();

        // Add all views to the dictionary
        views.Add("LanguageOption", GameObject.Find("/Ui/LanguageCanvas"));
        views.Add("ListView", GameObject.Find("/Ui/ListViewCanvas"));
        views.Add("DictrionaryOption", GameObject.Find("/Ui/DictionaryOptionCanvas"));
        views.Add("DictionaryLanguage", GameObject.Find("/Ui/DictionaryLanguageCanvas"));
        views.Add("Category", GameObject.Find("/Ui/CategoryCanvas"));

        // Hiding all view
        foreach (GameObject view in views.Values)
        {
            view.active = false;
        }
    }
    private void Start()
    {

        views["LanguageOption"].active = true;


        //a.active = false;

        Debug.Log("Text: " + "test");
        SwitchToView(initialView);
    }

  

    private void SwitchToView(View targetView)
    {
        if (currentView == targetView) return;
        
        foreach (var view in views.Values)
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
    }

    public void AboutButtonPressed()
    {
        SwitchToView(GetViewByTitle("About"));
    }
    
    public void StartButtonPressed()
    {
        SwitchToView(GetViewByTitle("Start"));
    }

    private View GetViewByTitle(String title)
    {
        
        foreach (var view in views.Values)
        {
            if (view.GetComponent<View>().Title == title) return view.GetComponent<View>();
        }

        throw new ViewNotFoundException();
    }
}

internal class ViewNotFoundException : Exception
{
}
