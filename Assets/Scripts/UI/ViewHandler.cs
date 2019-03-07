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
        
        if(GamificationManager.Instance.User.LearningLanguage == Model.Language.None || 
            GamificationManager.Instance.User.Name == null)
        {
            initialView = GetViewByTitle("LanguageCanvas");
        } else
        {
            initialView = GetViewByTitle("Class");
        }

        //currentView = GetViewByTitle(initialView.Id);
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
                var text = targetView.Title;
                var cache = DataProvider.DataCache.Instance;

                if (cache.CheckForUiTranslationByKey(text))
                {
                    text = DataProvider.DataCache.Instance.GetUiTranslationByKey(text);
                }
                Header.title.text = text;
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
        if (currentView == null) return;

        var animations = currentView.GetComponentsInChildren<EasyTween>();

        foreach (var anim in animations)
        {
            // Only modify the actual Wave Animation, no unique components aside from EasyTween, but all are clones
            if (anim.name.Contains("(Clone)"))
            {
                anim.gameObject.SetActive(false);
                anim.animationParts.ObjectState = UITween.AnimationParts.State.OPEN;
            }
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
