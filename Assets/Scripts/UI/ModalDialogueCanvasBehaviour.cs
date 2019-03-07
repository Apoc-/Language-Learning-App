using System.Collections.Generic;
using System.Linq;
using DataProvider;
using Gamification;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ModalDialogueCanvasBehaviour : MonoBehaviour
    {
        [SerializeField] private ModalDialogueBehaviour _levelUpDialogue;
        [SerializeField] private ModalDialogueBehaviour _trophyDialogue;
        [SerializeField] private ModalDialogueBehaviour _trophyDetailDialogue;
        [SerializeField] private ResultScreenModalDialogueBehaviour _resultScreenDialogue;

        private readonly List<ModalDialogueBehaviour> _dialogues = new List<ModalDialogueBehaviour>();
        private readonly List<ModalDialogueBehaviour> _activeDialogues = new List<ModalDialogueBehaviour>();


        private void Start()
        {
            _dialogues.Add(_levelUpDialogue);
            _dialogues.Add(_trophyDialogue);
            _dialogues.Add(_trophyDetailDialogue);
            _dialogues.Add(_resultScreenDialogue);
        }

        public void EnableLevelUpDialogue()
        {
            //todo localization
            if (!gameObject.activeSelf) gameObject.SetActive(true);
            _levelUpDialogue.gameObject.SetActive(true);
            _activeDialogues.Add(_levelUpDialogue);
        }

        public void EnableTrophyDialogue(Trophy trophy)
        {
            var text = DataCache.Instance.GetUiTranslationByKey("gratulations");
            text += "\n<b>{0}</b>";

            if (GamificationManager.Instance.User.UiLanguage == Language.Chinese)
            {
                text = text.Replace("{0}", trophy.Name.Chinese);
            }
            else
            {
                text = text.Replace("{0}", trophy.Name.German);
            }

            _trophyDialogue.Image.GetComponent<Image>().sprite = trophy.Image;
            _trophyDialogue.Text.GetComponent<Text>().text = text;

            if (!gameObject.activeSelf) gameObject.SetActive(true);
            _trophyDialogue.gameObject.SetActive(true);
            _activeDialogues.Add(_trophyDialogue);
        }

        public void EnableTrophyDetailDialogue(Trophy trophy)
        {
            var text = "\n<b>{0}</b>";

            if (GamificationManager.Instance.User.UiLanguage == Language.Chinese)
            {
                text = text.Replace("{0}", trophy.Name.Chinese);
            }
            else
            {
                text = text.Replace("{0}", trophy.Name.German);
            }

            _trophyDialogue.Image.GetComponent<Image>().sprite = trophy.Image;
            _trophyDialogue.Text.GetComponent<Text>().text = text;

            if (!gameObject.activeSelf) gameObject.SetActive(true);
            _trophyDialogue.gameObject.SetActive(true);
            _activeDialogues.Add(_trophyDialogue);
        }

        public void EnableResultScreenDialogue(int percentage)
        {
            _resultScreenDialogue.CorrectText.text = percentage.ToString() + "%";

            if (!gameObject.activeSelf) gameObject.SetActive(true);
            _resultScreenDialogue.gameObject.SetActive(true);
            _activeDialogues.Add(_resultScreenDialogue);
        }

        public void DismissDialogue()
        {
            var last = _activeDialogues.Last();
            _activeDialogues.RemoveAll(dia => dia == last);

            last.gameObject.SetActive(false);

            if (_activeDialogues.Count == 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void DisableAllDialogues()
        {
            foreach (var dia in _dialogues)
            {
                dia.gameObject.SetActive(false);
            }
        }
    }
}
