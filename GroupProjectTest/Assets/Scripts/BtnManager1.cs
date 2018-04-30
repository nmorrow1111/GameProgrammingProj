using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager1 : MonoBehaviour
{
    public void Retry(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene);
    }
    

}