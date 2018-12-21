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
    
    public View[] views;
    #endregion

    private void Start()
    {
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
