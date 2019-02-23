﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DictonaryLearningCanvas : MonoBehaviour
{
    public void DictionaryOrLearningOptions()
    {
        var selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {
            case "Learning":
                ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.Learn;
                //TODO: Switch to Learning Views
                break;

            case "Dictionary":
                ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.Dictionary;
                ViewHandler.Instance.SwitchToView("Category");
                break;

            case "ReturnButton":
                ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.None;
                ViewHandler.Instance.SwitchToView("Class");
                break;

            default:
                Debug.Log("Dictionary or Learning button select Error");
                break;
        }
    }
}
