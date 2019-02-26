using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueListRow : MonoBehaviour
{
    private DialogueData data;
    public GameObject dialogue_ballon_left;
    public GameObject dialogue_ballon_right;

    public void PopulateUI(DialogueData data, bool speeker)
    {
        this.data = data;
        transform.Find("german").GetComponent<Text>().text = data.German.Text;
        transform.Find("taiwanese").GetComponent<Text>().text = data.Taiwanese.Text;
        
        if (speeker){
        	dialogue_ballon_left.SetActive(false);
       		dialogue_ballon_right.SetActive(true);
        }else{
        	dialogue_ballon_left.SetActive(true);
       		dialogue_ballon_right.SetActive(false);
        }
       
       
    }
}
