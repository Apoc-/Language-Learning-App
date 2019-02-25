﻿using System.Collections;
using System.Collections.Generic;
using DataAccess;
using Gamification;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanguageCanvas : MonoBehaviour
{
    public void LanguageSelect()
    {
        var language = EventSystem.current.currentSelectedGameObject.name;
        var user = GamificationManager.Instance.User;
            
        switch (language)
        {
            case "German":
                user.LearningLanguage = Language.German;
                user.UiLanguage = Language.Taiwanese;
                
                ViewHandler.Instance.SwitchToView("Class");
                break;
            case "Chinese":
                user.LearningLanguage = Language.Taiwanese;
                user.UiLanguage = Language.German;
                
                ViewHandler.Instance.SwitchToView("Class");
                break;

            default:
                Debug.Log("Language button select Error");
                break;
        }
        
        DAOFactory.UserDAO.WriteUser(user);
        GamificationManager.Instance.InitializeTrophyHandler();
    }
}