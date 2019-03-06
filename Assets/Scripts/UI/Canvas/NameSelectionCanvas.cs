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
        var user = Gamification.GamificationManager.Instance.User;
        user.Name = InputName;
        DAOFactory.UserDAO.WriteUser(user);
        ViewHandler.Instance.SwitchToView("Class");
        
    }
    public void ResetInput()
    {
        Debug.Log("fic");
        InputFeild.Select();
        InputFeild.text = "";
    }

}
