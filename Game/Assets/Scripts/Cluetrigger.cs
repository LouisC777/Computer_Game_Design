using UnityEngine;
using TMPro;  // Make sure you're using TextMeshPro

public class Cluetrigger : MonoBehaviour
{
    public GameObject infoBox;              // The UI panel to show
    public TextMeshProUGUI infoText;        // The text inside the panel
    public string clueMessage = "This is a clue."; // Editable message in inspector
    public GameObject eHint1;                // Optional: hint like "Press E"

    private bool isNear = false;

    void Start()
    {
        if (infoBox != null) infoBox.SetActive(false);
        if (eHint1 != null) eHint1.SetActive(false);
      
            if (eHint1 == null)
            {
                Debug.LogWarning("eHint is not assigned.");
            }
            else
            {
                Debug.Log("eHint is assigned.");
            
        }
    }

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInfoBox();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            
            if (eHint1 != null) eHint1.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            if (eHint1 != null) eHint1.SetActive(false);
            if (infoBox != null) infoBox.SetActive(false);
        }
    }

    void ToggleInfoBox()
    {
        
        if (infoBox != null)
        {
            bool isActive = infoBox.activeSelf;
            infoBox.SetActive(!isActive);

            if (!isActive && infoText != null)
            {
                infoText.text = clueMessage;
            }
        }
    }
}
