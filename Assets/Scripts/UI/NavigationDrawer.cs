using UnityEngine;

public class NavigationDrawer : MonoBehaviour
{
    public GameObject HomeButton;
    public GameObject MenuButton;
    public GameObject BackButton;

    public void SwitchToProfileCanvas()
    {
        ViewHandler.Instance.SwitchToView("ProfileCanvas");
    }
    public void AboutCanvas()
    {
        ViewHandler.Instance.SwitchToView("AboutCanvas");
    }
    public void EnableHomeButton()
    {
        DisableAllButtons();
        HomeButton.SetActive(true);
    }

    public void EnableMenuButton()
    {
        DisableAllButtons();
        MenuButton.SetActive(true);
    }

    string backTarget = "Class";
    public void EnableBackButton(string target)
    {
        backTarget = target;
        DisableAllButtons();
        BackButton.SetActive(true);
    }

    public void DisableAllButtons()
    {
        HomeButton.SetActive(false);
        MenuButton.SetActive(false);
        BackButton.SetActive(false);
    }

    public void OnHomebuttonPress()
    {
        ViewHandler.Instance.SwitchToView("Class");
        EnableMenuButton();
    }
}