using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCellOnClickEvent : MonoBehaviour
{
    public GameObject TestingViewPrefab;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        Debug.Log("Button down");
        ViewHandler.Instance.CurrentListItem = this.gameObject.name;
        Instantiate(TestingViewPrefab);
    }
}
