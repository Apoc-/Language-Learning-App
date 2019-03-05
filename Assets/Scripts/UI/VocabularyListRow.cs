using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyListRow : MonoBehaviour
{
    private Vocabulary data;

    public void OnRowClicked()
    {
        ViewHandler.Instance.CurrentListItem = data.Id;
        var view = ViewHandler.Instance.SwitchToView("VocabularyDetailView");
        view.GetComponent<VocabularyDetailCanvas>().PopulateUI(data);
    }

    public void PopulateUI(Vocabulary data)
    {
        this.data = data;
        name = data.Id;
        transform.Find("Chinese").GetComponent<Text>().text = data.Translation[Language.Taiwanese];
        transform.Find("German").GetComponent<Text>().text = data.Translation[Language.German];
    }
}
