using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    public Canvas Quit;
    public Button Retry;
    public Button Exit1;
   

    // Use this for initialization
    void Start()
    {
        Quit = Quit.GetComponent<Canvas>();
        Exit1 = Exit1.GetComponent<Button>();
        Retry = Retry.GetComponent<Button>();
        Quit.enabled = false;
    }
    public void ExitPress()
    {
        Quit.enabled = true;
        Exit1.enabled = false;
        Retry.enabled = false;

    }
    public void NoPress()
    {
        Quit.enabled = false;
        Exit1.enabled = true;
        Retry.enabled = true;

    }
    public void YesPress()
    {
        Application.Quit();
    }

}