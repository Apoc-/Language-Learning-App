using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataAccess;
using DataAccess.DataHelpers;
using UnityEngine.UI;

public class NameSelectionCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public NavigationDrawer NavigationDrawer;
    
    public string InputName;
    public InputField InputFeild;
    public GameObject ConfirmButton;
    public GameObject ResetButton;

    private void Start()
    {

        NavigationDrawer.DisableAllButtons();
        JsonGenerator.GenerateSayingJsonFromSource();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameInput()
    {
        InputName = InputFeild.text;
        Gamification.GamificationManager.Instance.User.Name = InputName;
        ViewHandler.Instance.SwitchToView("LanguageCanvas");
        Debug.Log("User name is " + InputName); 
    }
    public void ResetInput()
    {
        Debug.Log("fic");
        InputFeild.Select();
        InputFeild.text = "";
    }

}
