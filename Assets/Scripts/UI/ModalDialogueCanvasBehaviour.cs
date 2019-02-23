using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class ModalDialogueCanvasBehaviour : MonoBehaviour
    {
        [SerializeField]
        private ModalDialogueBehaviour _levelUpDialogue;

        private readonly List<ModalDialogueBehaviour> dialogues = new List<ModalDialogueBehaviour>();

        private void Start()
        {
            dialogues.Add(_levelUpDialogue);
        }

        public void EnableLevelUpDialogue()
        {
            gameObject.SetActive(true);
            DisableAllDialogues();

            _levelUpDialogue.gameObject.SetActive(true);
        }

        public void DismissDialogue()
        {
            gameObject.SetActive(false);
        }

        private void DisableAllDialogues()
        {
            foreach (var dia in dialogues)
            {
                dia.gameObject.SetActive(false);
            }
        }
    }
}
