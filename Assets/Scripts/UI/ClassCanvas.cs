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
                ViewHandler.Instance.CurrentClass = ViewHandler.ClassType.Alphabet;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Vocabulary":
                ViewHandler.Instance.CurrentClass = ViewHandler.ClassType.Vocabulary;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Dialogue":
                ViewHandler.Instance.CurrentClass = ViewHandler.ClassType.Dialogue;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Saying":
                ViewHandler.Instance.CurrentClass = ViewHandler.ClassType.Saying;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "ReturnButton":
                ViewHandler.Instance.CurrentClass = ViewHandler.ClassType.None;
                ViewHandler.Instance.SwitchToView("LanguageCanvas");
                break;

            default:
                Debug.Log("Class button select Error");
                break;
        }
    }
}
