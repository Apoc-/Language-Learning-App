using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class CategoryHandler : MonoBehaviour
{
    public GameObject CategoryItemPrefab;
    public List<CategoryItem> CategoryData = new List<CategoryItem>();
   
    private void OnEnable()
    {
        CategoryData.Add(new CategoryItem("icon_testing", "A", "Some Description..."));
        CategoryData.Add(new CategoryItem("icon_testing", "B", "Some Description..."));
        CategoryData.Add(new CategoryItem("icon_testing", "C", "Some Description..."));
        CategoryData.Add(new CategoryItem("icon_testing", "D", "Some Description..."));
        CategoryData.Add(new CategoryItem("icon_testing", "E", "Some Description..."));
        CategoryData.Add(new CategoryItem("icon_testing", "F", "Some Description..."));


        foreach (CategoryItem item in CategoryData)
        {


            GameObject table = GameObject.Find("CategoryCanvas/Category/GridElements");
            GameObject row = GameObject.Instantiate(CategoryItemPrefab, table.transform.position, table.transform.rotation) as GameObject;
            row.name = item.Title;
            row.transform.SetParent(table.transform);

            row.transform.Find("Image").GetComponent<Image>().sprite = item.ItemImage;
            row.transform.Find("Title").GetComponent<Text>().text = item.Title;
            row.transform.Find("Description").GetComponent<Text>().text = item.Description;


        }

        // Testing ViewMap data * 
        Debug.Log("Class is " + ViewHandler.ViewMap["Class"]);
    }


    public class CategoryItem
    {
        public Sprite ItemImage;
        public string Title;
        public string Description;

        private string IMAGE_RESOURCES_PATH = "Image/testing/";

        public CategoryItem(string newItemImage, string newTitle, string newDescription)
        {

            ItemImage = Resources.Load<Sprite>(IMAGE_RESOURCES_PATH + newItemImage);
            Title = newTitle;
            Description = newDescription;
        }
    }




}