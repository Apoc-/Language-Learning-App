using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryItem : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("Button down");
        ViewHandler.Instance.CurrentCategory = this.gameObject.name;
        var view = ViewHandler.Instance.SwitchToView("ListView");
        view.GetComponent<ListView>().ViewToReturnTo = "Category";

    }
}
