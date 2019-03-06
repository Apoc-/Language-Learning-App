using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClassCanvas : MonoBehaviour
{
    public void OnEnable()
    {
        ViewHandler.Instance.NavigationDrawer.EnableMenuButton();
    }

    public void ClassSelect()
    {
        var Class = EventSystem.current.currentSelectedGameObject.name;
        switch (Class)
        {
            case "Alphabet/Phonics":
                ViewHandler.Instance.CurrentClass = ClassType.Alphabet;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Vocabulary":
                ViewHandler.Instance.CurrentClass = ClassType.Vocabulary;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Dialogue":
                ViewHandler.Instance.CurrentClass = ClassType.Dialogue;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Saying":
                ViewHandler.Instance.CurrentClass = ClassType.Saying;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "ReturnButton":
                ViewHandler.Instance.CurrentClass = ClassType.None;
                ViewHandler.Instance.SwitchToView("LanguageCanvas");
                break;

            default:
                Debug.Log("Class button select Error");
                break;
        }
    }
}
