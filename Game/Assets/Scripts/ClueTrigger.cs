using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public GameObject cluePanel;
    public GameObject cluePrompt;

    private bool playerInZone = false;

    void Start()
    {
        cluePanel.SetActive(false);
        cluePrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            cluePanel.SetActive(true);
            cluePrompt.SetActive(false);
            Time.timeScale = 0f; // Pause the game (optional)
        }
    }

    public void CloseClue()
    {
        cluePanel.SetActive(false);
        Time.timeScale = 1f; // Resume game
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            cluePrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            cluePrompt.SetActive(false);
        }
    }
}
