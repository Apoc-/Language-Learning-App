using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClassCanvas : MonoBehaviour
{
    public bool EnableIntegrityCheck;

    public void OnEnable()
    {
        ViewHandler.Instance.NavigationDrawer.EnableMenuButton();
        CheckDataIntegrity();
        Gamification.GamificationManager.Instance.TrophyHandler.CheckTrophyConditions();
    }

    private void CheckDataIntegrity()
    {
        if (!EnableIntegrityCheck) return;

        int totalAudio = 0;
        int missingAudio = 0;

        int totalImages = 0;
        int missingImages = 0;

        DataAccess.DAOFactory.AlphabetDAO.LoadAlphabet().ForEach(a => a.Entries.ForEach(ae =>
        {
            totalAudio += 3;
            if (ae.ContextFreeAudio.Audio == null)
            { missingAudio++; Debug.LogError("Audio " + ae.ContextFreeAudio.Path + " is missing"); }
            if (ae.ContextSensitiveAudio.Audio == null)
            { missingAudio++; Debug.LogError("Audio " + ae.ContextSensitiveAudio.Path + " is missing"); }
            if (ae.ExampleWordAudio.Audio == null)
            { missingAudio++; Debug.LogError("Audio " + ae.ExampleWordAudio.Path + " is missing"); }
        }));

        Debug.Log(string.Format("{0}/{1} audio files missing", missingAudio, totalAudio));
        Debug.Log(string.Format("{0}/{1} image files missing", missingImages, totalImages));

        DataAccess.DAOFactory.VocabularyDAO.LoadVocabulary().ForEach(v =>
        {
            totalImages++;
            totalAudio += 2;
            if (v.Image.Sprite == null) { missingImages++; Debug.LogError("Image " + v.Image.Path + " is missing"); }
            if (v.Audio[Model.Language.Chinese].Audio == null) { missingAudio++; Debug.LogError("Audio " + v.Audio[Model.Language.Chinese].Path + " is missing"); };
            if (v.Audio[Model.Language.German].Audio == null) { missingAudio++; Debug.LogError("Audio " + v.Audio[Model.Language.German].Path + " is missing"); };
        });

        Debug.Log(string.Format("{0}/{1} audio files missing", missingAudio, totalAudio));
        Debug.Log(string.Format("{0}/{1} image files missing", missingImages, totalImages));

        DataAccess.DAOFactory.DialogueDAO.LoadDialogues().ForEach(d => d.Entries.Values.ToList().ForEach(de => de.ForEach(dee =>
        {
            totalAudio++;
            if (dee.Audio.Audio == null) { missingAudio++; Debug.LogError("Audio " + dee.Audio.Path + " is missing"); }; 
        })));

        Debug.Log(string.Format("{0}/{1} audio files missing", missingAudio, totalAudio));
        Debug.Log(string.Format("{0}/{1} image files missing", missingImages, totalImages));

        DataAccess.DAOFactory.SayingDAO.LoadSayings().ForEach(s =>
        {
            totalAudio++;
            if (s.Audio.Audio == null) { missingAudio++; Debug.LogError("Audio " + s.Audio.Path + " is missing"); };
        });

        Debug.Log(string.Format("{0}/{1} audio files missing", missingAudio, totalAudio));
        Debug.Log(string.Format("{0}/{1} image files missing", missingImages, totalImages));

    }

    public void ClassSelect()
    {
        var Class = EventSystem.current.currentSelectedGameObject.name;
        switch (Class)
        {
            case "Alphabet/Phonics":
                ViewHandler.Instance.CurrentClass = ClassType.Alphabet;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Vocabulary":
                ViewHandler.Instance.CurrentClass = ClassType.Vocabulary;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Dialogue":
                ViewHandler.Instance.CurrentClass = ClassType.Dialogue;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "Saying":
                ViewHandler.Instance.CurrentClass = ClassType.Saying;
                ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                break;

            case "ReturnButton":
                ViewHandler.Instance.CurrentClass = ClassType.None;
                ViewHandler.Instance.SwitchToView("LanguageCanvas");
                break;

            default:
                Debug.Log("Class button select Error");
                break;
        }
    }
}
