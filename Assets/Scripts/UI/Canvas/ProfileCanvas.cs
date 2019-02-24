using Gamification;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Canvas
{
    public class ProfileCanvas : MonoBehaviour
    {
        public GameObject Name;
        public GameObject Level;

        private void OnEnable()
        {
            ViewHandler.Instance.NavigationDrawer.EnableHomeButton();
            var user = GamificationManager.Instance.User;
            Name.GetComponent<Text>().text = user.Name;
            Level.GetComponent<Text>().text = "Level " + user.Level;
        }
    }
}