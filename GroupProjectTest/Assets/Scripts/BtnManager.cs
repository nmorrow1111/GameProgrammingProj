using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void StartBtn(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene);
    }
    public void MainMenuBtn(string StartScreen)
    {
        SceneManager.LoadScene(StartScreen);
    }
}
