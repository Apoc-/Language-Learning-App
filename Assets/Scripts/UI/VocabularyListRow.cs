using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyListRow : MonoBehaviour
{
    public void OnRowClicked()
    {
        ViewHandler.Instance.CurrentListItem = this.gameObject.name;
        ViewHandler.Instance.SwitchToView("");
    }

    public void PopulateUI(Vocabulary data)
    {
        name = data.Id;
        transform.Find("Chinese").GetComponent<Text>().text = data.Translation[Language.Taiwanese];
        transform.Find("German").GetComponent<Text>().text = data.Translation[Language.German];
    }
}
