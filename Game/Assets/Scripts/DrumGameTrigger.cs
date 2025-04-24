using UnityEngine;

public class DrumGameTrigger : MonoBehaviour
{
    public GameObject drumPanel;         // ��UI���
    public GameObject interactionHint;   // ����E���ࡱ��ʾ
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
            Time.timeScale = 0f; // ��ͣ��Ϸ����ѡ��
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
            Time.timeScale = 1f; // �ָ���Ϸ
        }
    }
}
