using UnityEngine;

public class NavigationDrawer : MonoBehaviour
{
        public GameObject HomeButton;
        public GameObject MenuButton;
        
        public void SwitchToProfileCanvas()
        {
                ViewHandler.Instance.SwitchToView("ProfileCanvas");
        }

        public void EnableHomeButton()
        {
                MenuButton.SetActive(false);
                HomeButton.SetActive(true);
        }
        
        public void EnableMenuButton()
        {
                HomeButton.SetActive(false);
                MenuButton.SetActive(true);
        }

        public void OnHomebuttonPress()
        {
                ViewHandler.Instance.SwitchToView("Class");
                EnableMenuButton();
        }
}