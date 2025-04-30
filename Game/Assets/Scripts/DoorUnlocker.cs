using UnityEngine;
using TMPro;

public class DoorUnlocker : MonoBehaviour
{
    [Header("UI 组件")]
    public GameObject doorInputPanel;       // 输入密码面板
    public TMP_InputField inputField;       // 输入框
    public GameObject promptText;           // 提示文字，如“Press E to interact”

    [Header("谜题逻辑")]
    public PuzzleManager puzzleManager;     // 开门控制器
    public string Ans1 = "Asia";   // 正确答案
    public string Ans2 = "asia";   // 正确答案
    public string Ans3 = "ASIA";   // 正确答案

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenInputPanel();
        }
    }

    private void OpenInputPanel()
    {
        if (doorInputPanel != null)
        {
            doorInputPanel.SetActive(true);
        }

        if (inputField != null)
        {
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }

        if (promptText != null)
        {
            promptText.SetActive(false);
        }
    }

    public void SubmitInput()
    {
        string answer = inputField.text.Trim();

        if (answer == Ans1 || answer == Ans2 || answer == Ans3)
        {
            Debug.Log("✅ 密码正确，门已打开！");
            puzzleManager.OnPuzzleSolved();
            doorInputPanel.SetActive(false);
        }
        else
        {
            Debug.Log("❌ 密码错误！");
            inputField.text = "";
            inputField.Select();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (promptText != null)
                promptText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptText != null)
                promptText.SetActive(false);
        }
    }
}
