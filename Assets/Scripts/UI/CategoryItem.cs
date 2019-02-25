using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryItem : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (ViewHandler.Instance.LearnOrDictionary == ViewHandler.LearnOrDic.Dictionary)
        {
            ViewHandler.Instance.CurrentCategory = this.gameObject.name;
            var view = ViewHandler.Instance.SwitchToView("ListView");
            view.GetComponent<ListView>().ViewToReturnTo = "Category";
        }
        else
        {
            ViewHandler.Instance.CurrentCategory = this.gameObject.name;
            var view = ViewHandler.Instance.SwitchToView("LearnStartView");
            view.GetComponent<LearnStartViewCanvas>().ViewToReturnTo = "Category";
        }


    }
}
