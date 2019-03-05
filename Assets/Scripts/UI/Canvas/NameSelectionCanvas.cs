using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSelectionCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public NavigationDrawer NavigationDrawer;
    
    public string InputName;
    public GameObject ConfirmButton;
    public GameObject ResetButton;

    private void Start()
    {

        NavigationDrawer.DisableAllButton();
        JsonGenerator.GenerateTranslationJsonFromSource();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
