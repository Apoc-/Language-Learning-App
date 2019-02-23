using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClassCanvas : MonoBehaviour
{
    public void ClassSelect()
    {
        var Class = EventSystem.current.currentSelectedGameObject.name;
        switch (Class)
        {
            case "Alphabet/Phonics":
                ViewHandler.Instance.ViewMap["Class"] = "Alphabet/Phonics";
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Vocabulary":
                ViewHandler.Instance.ViewMap["Class"] = "Vocabulary";
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Greeting":
                ViewHandler.Instance.ViewMap["Class"] = "Greeting";
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Saying":
                ViewHandler.Instance.ViewMap["Class"] = "Saying";
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "ReturnButton":
                ViewHandler.Instance.ViewMap["Class"] = null;
                ViewHandler.Instance.SwitchToView("LanguageCanvas");
                break;

            default:
                Debug.Log("Class button select Error");
                break;
        }
    }
}
