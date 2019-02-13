using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageCanvas : MonoBehaviour
{


    private Canvas canvas; 

    private void Awake()
    {

        canvas = GetComponent<Canvas>();

        Debug.Log("Test " + canvas.name);



    }
    private void Update()
    {

    }
}
