using System;
using UnityEngine;

public class LearnStartViewCanvas : MonoBehaviour
{
    public string ViewToReturnTo { get; set; }

    private void OnEnable()
    {

    }

    public void ReturnButton()
    {
        if (ViewHandler.Instance.CurrentClass == UI.ClassType.Alphabet)
        {
            ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.None;
            ViewHandler.Instance.SwitchToView("Dictionary or Learning");
        }
        else
        {
            ViewHandler.Instance.CurrentCategory = null;
            ViewHandler.Instance.SwitchToView("Category");
        }
    }
}