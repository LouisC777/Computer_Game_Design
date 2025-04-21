using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public GameObject clueImage;   // This is now the Image instead of a panel
    public GameObject cluePrompt;

    private bool playerInZone = false;

    void Start()
    {
        clueImage.SetActive(false);
        cluePrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            clueImage.SetActive(true);
            cluePrompt.SetActive(false);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void CloseClue()
    {
        clueImage.SetActive(false);
        Time.timeScale = 1f; // Resume the game
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
