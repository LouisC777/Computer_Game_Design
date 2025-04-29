using UnityEngine;
using TMPro; // 记得导入TextMeshPro命名空间

public class DoorUnlocker : MonoBehaviour
{
    public GameObject doorInputPanel;
    public TMP_InputField inputField;
    public PuzzleManager puzzleManager;

    private bool playerInTrigger = false;

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            OpenInputPanel();
        }
    }

    private void OpenInputPanel()
    {
        doorInputPanel.SetActive(true);
        inputField.text = "";
        inputField.Select(); // 自动选中输入框
    }

    public void SubmitInput()
    {
        string answer = inputField.text.Trim();

        if (answer == "3.14")
        {
            Debug.Log("密码正确，开门！");
            puzzleManager.OnPuzzleSolved();
            doorInputPanel.SetActive(false);
        }
        else
        {
            Debug.Log("密码错误！");
            inputField.text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            Debug.Log("靠近厕所门，按E输入密码");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
