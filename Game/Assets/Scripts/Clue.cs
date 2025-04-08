using UnityEngine;

public class Clue : MonoBehaviour
{
    public string clueText = "A strange symbol is etched into the wall...";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Clue Found: " + clueText);
            // Trigger clue display (UI popup, log, etc.)
            //TutorialPuzzleManager.Instance.FoundClue();
            Destroy(gameObject); // Remove clue after it's found
        }
    }
}
