using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gamification;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
public class ViewHandler : Singleton<ViewHandler>
{
    public Header Header;
    public NavigationDrawer NavigationDrawer;
    public ModalDialogueCanvasBehaviour ModalDialogueCanvas;

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

    public View SwitchToView(string targetViewTitle)
    {
        return SwitchToView(GetViewByTitle(targetViewTitle));
    }

    public View SwitchToView(View targetView)
    {
        EndOldAnimations();

        if (currentView == targetView) return currentView;
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
        return currentView;
    }

    private void EndOldAnimations()
    {
        var animations = currentView.GetComponentsInChildren<EasyTween>();
        foreach (var anim in animations)
        {
            //anim.animationParts.FinalEnd();
        }
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
        return views.ToList().FirstOrDefault(v => v.Id == title)
            ?? throw new Exception("View " + title + " was not found");
    }
}
