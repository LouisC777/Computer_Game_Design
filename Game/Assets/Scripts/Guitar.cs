using UnityEngine;

public class Guitar : MonoBehaviour
{
    public GameObject interactionHint; // 提示文字，如“Press E to interact”
    public GameObject puzzlePanel;     // 要弹出的Panel
    private bool playerInRange = false;

    void Start()
    {
        if (interactionHint) interactionHint.SetActive(false);
        if (puzzlePanel) puzzlePanel.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactionHint.SetActive(false);
            puzzlePanel.SetActive(true);
            Time.timeScale = 0f; // 暂停时间（可选）
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactionHint) interactionHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactionHint) interactionHint.SetActive(false);
        }
    }
}
