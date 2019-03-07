using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyDetailCanvas : MonoBehaviour
{
    public Image Image;
    public Text ForeignText;
    public Text LocalText;
    public AudioSource AudioSource;

    public Text BopomofoText;

    private Vocabulary data;
    private User user;

    public void PopulateUI(Vocabulary data)
    {
        this.data = data;
        this.user = Gamification.GamificationManager.Instance.User;

        ForeignText.text = data.Translation[user.LearningLanguage];
        BopomofoText.text = "(" + data.Bopomofo + ")";
        BopomofoText.gameObject.SetActive(user.LearningLanguage == Language.Chinese);

        LocalText.text = data.Translation[user.UiLanguage];
        Image.sprite = data.Image.Sprite;
    }

    public void PlayForeignAudio()
    {
        AudioSource.Stop();
        AudioSource.clip = data.Audio[user.LearningLanguage].Audio;
        AudioSource.Play();
    }

    public void PlayLocalAudio()
    {
        AudioSource.Stop();
        AudioSource.clip = data.Audio[user.UiLanguage].Audio;
        AudioSource.Play();
    }

    public void ReturnButton()
    {
        ViewHandler.Instance.CurrentListItem = null;
        ViewHandler.Instance.SwitchToView("ListView");
    }
}
