using System.Collections;
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
                ViewHandler.Instance.ViewMap["LearnOrDic"] = "Learning";
                //TODO: Switch to Learning Views
                break;

            case "Dictionary":
                ViewHandler.Instance.ViewMap["LearnOrDic"] = "Dictionary";
                ViewHandler.Instance.SwitchToView("Category");
                break;

            case "ReturnButton":
                ViewHandler.Instance.ViewMap["LearnOrDic"] = null;
                ViewHandler.Instance.SwitchToView("Class");
                break;

            default:
                Debug.Log("Dictionary or Learning button select Error");
                break;
        }
    }
}
