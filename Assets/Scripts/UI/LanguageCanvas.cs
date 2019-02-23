using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanguageCanvas : MonoBehaviour
{
    public void LanguageSelect()
    {
        var language = EventSystem.current.currentSelectedGameObject.name;
        switch (language)
        {
            case "German":
                ViewHandler.Instance.SwitchToView("Class");
                break;
            case "Chinese":
                ViewHandler.Instance.SwitchToView("Class");
                break;

            default:
                Debug.Log("Language button select Error");
                break;
        }
    }
}
