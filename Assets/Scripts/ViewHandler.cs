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

    private void Start()
    {

        views = GetComponentsInChildren<View>();
        currentView = GetViewByTitle("Category");
        foreach (var view in views)
        {
            Debug.Log("Fic " + view.name);
        }
        SwitchToView(initialView);
    }

    private void SwitchToView(View targetView)
    {

        Debug.Log("Ficssss " + currentView.name);
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
        if (EventSystem.current.currentSelectedGameObject.name == "German")
        {

        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Chinese")
        {

        }
        SwitchToView(GetViewByTitle("Class"));
    }


    public void ClassSelect()
    {
        var Class = EventSystem.current.currentSelectedGameObject.name;
        switch (Class)
        {
            case "Alphabet/Phonics":
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "Vocabulary":
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "Greeting":
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            case "Saying":
                SwitchToView(GetViewByTitle("Dictionary or Learning"));
                break;
            default:
                Debug.Log("Class button select Error");
                break;

        }

    }
    private View GetViewByTitle(String title)
    {

        foreach (var view in views)
        {
            if (view.Title == title) return view;
        }

        throw new ViewNotFoundException();
    }
}

internal class ViewNotFoundException : Exception
{
}
