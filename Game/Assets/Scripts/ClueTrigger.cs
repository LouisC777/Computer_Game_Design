using UnityEngine;
using TMPro;

public class ClueTrigger : MonoBehaviour
{
    public int clueIndex;
    public ClueData[] clues; // Change from Sprite[][] to ClueData[]

    public ClueImageViewer clueViewer;
    public ClueManager clueManager;
    public GameObject cluePrompt;

    public TextMeshProUGUI passwordDisplay;
    public string passwordPiece;

    private bool playerInZone = false;

    void Start()
    {
        if (cluePrompt != null)
        {
            cluePrompt.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (clueManager != null && clueManager.CanAccessClue(clueIndex))
            {
                if (clues != null && clueIndex < clues.Length && clues[clueIndex] != null && clues[clueIndex].clueImages.Length > 0)
                {
                    clueViewer.ShowClue(clues[clueIndex].clueImages);
                }
                else
                {
                    Debug.LogWarning("ClueData or Clue images are missing for clueIndex: " + clueIndex);
                }

                clueManager.UnlockClue(clueIndex);

                if (cluePrompt != null)
                {
                    cluePrompt.SetActive(false);
                }

                if (passwordDisplay != null)
                {
                    passwordDisplay.text += passwordPiece;
                }
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

            if (clueManager != null && clueManager.CanAccessClue(clueIndex))
            {
                if (cluePrompt != null)
                {
                    cluePrompt.SetActive(true);
                }
            }
            else
            {
                if (cluePrompt != null)
                {
                    cluePrompt.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;

            if (cluePrompt != null)
            {
                cluePrompt.SetActive(false);
            }
        }
    }
}
