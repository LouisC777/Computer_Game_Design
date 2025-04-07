using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}
