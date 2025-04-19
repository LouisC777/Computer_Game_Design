using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject codePanelUI;
    public GameObject interactPrompt;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            codePanelUI.SetActive(true);
            interactPrompt.SetActive(false); // Hide the prompt
            Time.timeScale = 0f; // Optional
        }
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
