using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CodeLock : MonoBehaviour
{
    public GameObject door;               // The locked door GameObject
    public GameObject codePanelUI;        // The UI panel with input field
    public TMP_InputField codeInput;      // TMP Input Field for code entry
    public string correctCode = "1234";   // Change this to your actual code
    public string nextSceneName;          // The name of the next scene
    public GameObject successPanel;

    public GameObject interactPrompt;     // "Press E to interact" UI
    private bool playerInRange = false;   // Is the player near the door?

    void Start()
    {
        codePanelUI.SetActive(false);     // Hide code panel at start
        interactPrompt.SetActive(false);  // Hide interaction prompt at start
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            codePanelUI.SetActive(true);
            interactPrompt.SetActive(false);
            Time.timeScale = 0f; // Pause the game (optional)
        }
    }

    public void SubmitCode()
    {
        if (codeInput.text == correctCode)
        {
            Debug.Log("Correct Code!");
            door.SetActive(false);
            codePanelUI.SetActive(false);
            Time.timeScale = 1f;

            if (successPanel != null)
            {
                successPanel.SetActive(true); // ✅ 显示成功面板
            }

            // 如果你想延迟跳转下一场景：
            // StartCoroutine(LoadNextSceneAfterDelay(2f));
        }
        
    }

    public void ClosePanel()
    {
        codePanelUI.SetActive(false); // Hide the code panel
        Time.timeScale = 1f;          // Resume game if paused
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactPrompt.SetActive(false);
        }
    }
}
