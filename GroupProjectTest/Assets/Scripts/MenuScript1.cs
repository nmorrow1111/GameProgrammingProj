using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript1 : MonoBehaviour
{
    public Canvas QuitScreen;
    public Button StartBtn;
    public Button ExitBtn;
    public Button ControlsBtn;

    // Use this for initialization
    void Start()
    {
        QuitScreen = QuitScreen.GetComponent<Canvas>();
        ExitBtn = ExitBtn.GetComponent<Button>();
        StartBtn = StartBtn.GetComponent<Button>();
        ControlsBtn = ControlsBtn.GetComponent<Button>();
        QuitScreen.enabled = false;
    }
    public void ExitPress()
    {
        QuitScreen.enabled = true;
        ExitBtn.enabled = false;
        StartBtn.enabled = false;
        ControlsBtn.enabled = false;

    }
    public void NoPress()
    {
        QuitScreen.enabled = false;
        ExitBtn.enabled = true;
        StartBtn.enabled = true;
        ControlsBtn.enabled = true;

    }
    public void YesPress()
    {
        Application.Quit();
    }
   
}
