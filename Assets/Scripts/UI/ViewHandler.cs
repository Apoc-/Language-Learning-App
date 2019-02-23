using System;
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

    public List<View> views = new List<View>();
    #endregion

    // Global variables to store data
    public ClassType CurrentClass;
    public LearnOrDic LearnOrDictionary;
    public string CurrentCategory;
    public string CurrentListItem;

    public enum ClassType
    {
        None,
        Alphabet,
        Vocabulary,
        Dialogue,
        Saying
    }

    public enum LearnOrDic
    {
        None,
        Learn,
        Dictionary
    }

    private void Start()
    {
        views = GetComponentsInChildren<View>(true).ToList();
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
        SwitchToView("About");
    }

    public void StartButtonPressed()
    {
        SwitchToView("Start");
    }

    private View GetViewByTitle(String title)
    {
        return views.ToList().FirstOrDefault(v => v.Title == title)
            ?? throw new Exception("View " + title + " was not found");
    }
}
