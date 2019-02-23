using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Model;

public class CategoryCanvas : MonoBehaviour
{
    public GameObject CategoryItemPrefab;
    public List<Category> CategoryData = new List<Category>();
   
    private void Start()
    {
        //CategoryData.Add(new CategoryItem("icon_testing", "A", "Some Description..."));
        //CategoryData.Add(new CategoryItem("icon_testing", "B", "Some Description..."));
        //CategoryData.Add(new CategoryItem("icon_testing", "C", "Some Description..."));
        //CategoryData.Add(new CategoryItem("icon_testing", "D", "Some Description..."));
        //CategoryData.Add(new CategoryItem("icon_testing", "E", "Some Description..."));
        //CategoryData.Add(new CategoryItem("icon_testing", "F", "Some Description..."));

        //TODO Use DataProvider instead
        //DataProvider.DataProvider.Instance.
        CategoryData = DataAccess.DAOFactory.CategoryDAO.LoadCategories();

        foreach (var item in CategoryData)
        {
            GameObject table = GameObject.Find("CategoryCanvas/Category/GridElements");
            GameObject row = GameObject.Instantiate(CategoryItemPrefab, table.transform) as GameObject;
            row.name = item.Id;

            //row.transform.Find("Image").GetComponent<Image>().sprite = item.ItemImage;
            row.transform.Find("Title").GetComponent<Text>().text = item.Id;
            row.transform.Find("Description").GetComponent<Text>().text = item.Name.German;
        }

        // Testing ViewMap data * 
        Debug.Log("Class is " + ViewHandler.Instance.ViewMap["Class"]);
    }

    public void CategorySelect()
    {
        var selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {
            case "ReturnButton":
                ViewHandler.Instance.ViewMap["Category"] = null;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            default:
                Debug.Log("Dictionary or Learning button select Error");
                break;

        }
    }

}