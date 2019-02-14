using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryItemOnClickEvent : MonoBehaviour
{
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
        Destroy(this.gameObject);
    }
}
