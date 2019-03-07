using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DictonaryLearningCanvas : MonoBehaviour
{
    public GameObject DictButton;
    public GameObject TestButton;

    public void OnEnable()
    {
        ViewHandler.Instance.NavigationDrawer.EnableBackButton("Dictionary or Learning");

  
        if (ViewHandler.Instance.CurrentClass == ClassType.Dialogue)
        {
            TestButton.GetComponent<Button>().interactable = false;
            TestButton.GetComponent<Image>().color = Color.gray / 2;
        } else
        {
            TestButton.GetComponent<Button>().interactable = true;
            TestButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void DictionaryOrLearningOptions()
    {
        var selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {
            case "Test":
                ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.Learn;
                if (ViewHandler.Instance.CurrentClass == ClassType.Alphabet
                    || ViewHandler.Instance.CurrentClass == ClassType.Saying)
                {
                    var view = ViewHandler.Instance.SwitchToView("LearnStartView");
                    //view.GetComponent<LearnStartViewCanvas>().ViewToReturnTo = "Dictionary or Learning";
                }
                else
                {
                    ViewHandler.Instance.SwitchToView("Category");
                }

                break;

            case "Lookup":
                ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.Dictionary;
                if (ViewHandler.Instance.CurrentClass == ClassType.Alphabet
                    || ViewHandler.Instance.CurrentClass == ClassType.Saying)
                {
                    var view = ViewHandler.Instance.SwitchToView("ListView");
                    view.GetComponent<ListView>().ViewToReturnTo = "Dictionary or Learning";
                }
                else
                {
                    ViewHandler.Instance.SwitchToView("Category");
                }

                break;

            case "ReturnButton":
                ViewHandler.Instance.CurrentClass = ClassType.None;
                ViewHandler.Instance.SwitchToView("Class");
                break;

            default:
                Debug.Log("Dictionary or Learning button select Error");
                break;
        }
    }
}
