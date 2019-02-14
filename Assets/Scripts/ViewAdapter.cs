using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class ViewAdapter : MonoBehaviour
{
    public GameObject Row_Prefab;
    public List<Vocabulary> CellData = new List<Vocabulary>();
    void Start()
    {

        CellData.Add(new Vocabulary("a","b"));
        CellData.Add(new Vocabulary("c","d"));
        CellData.Add(new Vocabulary("e","f"));
        CellData.Add(new Vocabulary("a", "b"));
        CellData.Add(new Vocabulary("c", "d"));
        CellData.Add(new Vocabulary("e", "f"));
        CellData.Add(new Vocabulary("a", "b"));
        CellData.Add(new Vocabulary("c", "d"));
        CellData.Add(new Vocabulary("e", "f"));
        CellData.Add(new Vocabulary("a", "b"));
        CellData.Add(new Vocabulary("c", "d"));
        CellData.Add(new Vocabulary("e", "f"));

        foreach (Vocabulary cell in CellData)
        {

            print(cell.German + " " + cell.Chinese);
            GameObject table = GameObject.Find("List/GridElements");
            GameObject row = GameObject.Instantiate(Row_Prefab, table.transform.position, table.transform.rotation) as GameObject;
            row.name = cell.Chinese;
            row.transform.SetParent(table.transform);
            row.transform.Find("Chinese").GetComponent<Text>().text = cell.Chinese;
            row.transform.Find("German").GetComponent<Text>().text = cell.German;


        }

    }



    public class Vocabulary
    {
        public string German;
        public string Chinese;

        public Vocabulary(string newGerman, string newChinese)
        {
            German = newGerman;
            Chinese = newChinese;
        }
    }

}