using UnityEngine;

public class DrumGameTrigger : MonoBehaviour
{
    public GameObject drumPanel;         // 鼓UI面板
    public GameObject interactionHint;   // “按E演奏”提示
    public GameObject eHint;
    private bool playerInside = false;

    void Start()
    {
        if (drumPanel) drumPanel.SetActive(false);
        if (interactionHint) interactionHint.SetActive(false);
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.F))
        {
            drumPanel.SetActive(true);
            interactionHint.SetActive(false);
            Time.timeScale = 0f; // 暂停游戏（可选）
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && eHint.activeSelf)
        {
            playerInside = true;
            if (interactionHint) interactionHint.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            if (interactionHint) interactionHint.SetActive(false);
            if (drumPanel) drumPanel.SetActive(false);
            Time.timeScale = 1f; // 恢复游戏
        }
    }
}
