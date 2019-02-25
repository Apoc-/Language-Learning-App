using Model;
using UnityEngine;

namespace UI
{
    public class TrophyButton : MonoBehaviour
    {
        public Trophy Trophy;

        public void OnPressed()
        {
            ViewHandler.Instance.ModalDialogueCanvas.EnableTrophyDetailDialogue(Trophy);
        }
    }
}