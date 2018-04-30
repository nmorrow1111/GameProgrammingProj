using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript2 : MonoBehaviour
{
    public Canvas ControlsCanvas;
    public Button StartBtn;
    public Button ExitBtn;
    public Button ControlsBtn;

    // Use this for initialization
    void Start()
    {
        ControlsCanvas = ControlsCanvas.GetComponent<Canvas>();
        ExitBtn = ExitBtn.GetComponent<Button>();
        StartBtn = StartBtn.GetComponent<Button>();
        ControlsBtn = ControlsBtn.GetComponent<Button>();
        ControlsCanvas.enabled = false;
    }
    public void ControlsPress()
    {
        ControlsCanvas.enabled = true;
        ExitBtn.enabled = false;
        StartBtn.enabled = false;
        ControlsBtn.enabled = false;

    }
    public void BackPress()
    {
        ControlsCanvas.enabled = false;
        ExitBtn.enabled = true;
        StartBtn.enabled = true;
        ControlsBtn.enabled = true;

    }
}
