﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
public class ViewHandler : Singleton<ViewHandler>
{
    public Header Header;
    public NavigationDrawer NavigationDrawer;

    #region VIEWS

    private View currentView;
    public View initialView;

    public View[] views;
    #endregion


    // Gloable variable to store data
    public Dictionary<string, string> ViewMap = new Dictionary<string, string> {
      {"Class",null}, {"LearnOrDic",null}, {"Category",null},{"List",null}
    };


    private void Start()
    {

        views = GetComponentsInChildren<View>();
        currentView = GetViewByTitle("Category");
        SwitchToView(initialView);
    }

    public void SwitchToView(string targetViewTitle)
    {
        SwitchToView(GetViewByTitle(targetViewTitle));
    }

    public void SwitchToView(View targetView)
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

    private View GetViewByTitle(String title)
    {
        return views.ToList().FirstOrDefault(v => v.Title == title)
            ?? throw new Exception("View " + title + " was not found");
    }
}
