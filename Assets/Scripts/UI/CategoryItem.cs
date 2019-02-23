using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryItem : MonoBehaviour
{
    public GameObject ListViewPrefab;

    public void OnMouseDown()
    {
        Debug.Log("Button down");
        ViewHandler.Instance.CurrentCategory  = this.gameObject.name;
        Instantiate(ListViewPrefab, ViewHandler.Instance.transform);

    }
}
