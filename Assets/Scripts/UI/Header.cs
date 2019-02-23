using Gamification;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Header : MonoBehaviour
    {
        public Text title;
        public ProgressBarBehaviour ProgressBar;

        public void EnableProgressBar()
        {
            ProgressBar.gameObject.SetActive(true);
        }
    
        public void DisableProgressBar()
        {
            ProgressBar.gameObject.SetActive(false);
        }
    }
}