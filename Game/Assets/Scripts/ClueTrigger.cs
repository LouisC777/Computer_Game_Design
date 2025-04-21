using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public Sprite[] clueSprites;                  // Images for this specific clue
    public ClueImageViewer clueViewer;            // Reference to viewer
    public GameObject cluePrompt;                 // "Press E to view" prompt

    private bool playerInZone = false;

    void Start()
    {
        cluePrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            clueViewer.ShowClue(clueSprites);     // Load this clue’s images
            cluePrompt.SetActive(false);
        }
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
