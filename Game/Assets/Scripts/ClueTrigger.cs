using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public int clueIndex;
    public Sprite[] clueSprites;
    public ClueImageViewer clueViewer;
    public ClueManager clueManager;
    public GameObject cluePrompt;

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
                clueManager.UnlockClue(clueIndex); // Unlock if it wasn’t before
                cluePrompt.SetActive(false);
            }
            else
            {
                Debug.Log("You need to find the previous clue first.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;

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
