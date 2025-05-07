using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 300f;
    public bool timerIsRunning = true;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timerText.text = "00:00";
                ShowGameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1f;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60f);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    // ✅ 确保场景名称完全匹配你的场景文件名
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
