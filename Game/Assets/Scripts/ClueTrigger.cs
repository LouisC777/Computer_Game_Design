using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public int clueIndex;                         // 0 = Clue 1, 1 = Clue 2, etc.
    public Sprite[] clueSprites;                  // Images for this clue
    public ClueImageViewer clueViewer;            // Reference to the clue image system
    public ClueManager clueManager;               // Reference to the clue progression system
    public GameObject cluePrompt;                 // UI "Press E" prompt

    private bool playerInZone = false;

    void Start()
    {
        cluePrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (clueManager.CanAccessClue(clueIndex))
            {
                clueViewer.ShowClue(clueSprites);
                clueManager.AdvanceClue();
                cluePrompt.SetActive(false);
            }
            else
            {
                Debug.Log("You need to find the previous clue first.");
                // Optionally show a locked clue message here
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;

            // Only show prompt if this clue is currently accessible
            if (clueManager.CanAccessClue(clueIndex))
            {
                cluePrompt.SetActive(true);
            }
            else
            {
                cluePrompt.SetActive(false);
            }
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
