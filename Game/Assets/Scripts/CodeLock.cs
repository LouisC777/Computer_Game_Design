using UnityEngine;
using TMPro;

public class CodeLock : MonoBehaviour
{
    public GameObject door; // Door GameObject to disable
    public GameObject codePanelUI; // The panel with input field and button
    public TMP_InputField codeInput;
    public string correctCode = "1234"; // You can change this

    public string nextSceneName; // The name of the next level scene

    public void SubmitCode()
    {
        if (codeInput.text == correctCode)
        {
            Debug.Log("Correct Code!");
            door.SetActive(false); // Unlock door (you could also play animation/sound)
            codePanelUI.SetActive(false);
            LoadNextLevel(); // Or you can use a trigger
        }
        else
        {
            Debug.Log("Wrong Code!");
            codeInput.text = "";
        }
    }

    void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
