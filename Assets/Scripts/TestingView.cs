﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("List data is => " + ViewHandler.ViewMap["List"]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReturnButton()
    {
        Debug.Log("Close Testing View ");
        Destroy(this.gameObject);
    }
}
