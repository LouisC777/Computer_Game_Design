using UnityEngine;
using UnityEngine.UI;

public class ClueAAWTrigger : MonoBehaviour
{
    public GameObject hintPaperImage;
    public GameObject pressEText;

    private bool isPlayerNear = false;

    void Start()
    {
        if (hintPaperImage != null) hintPaperImage.SetActive(false);
        if (pressEText != null) pressEText.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = hintPaperImage.activeSelf;
            hintPaperImage.SetActive(!isActive);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (pressEText != null) pressEText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (pressEText != null) pressEText.SetActive(false);
            if (hintPaperImage != null) hintPaperImage.SetActive(false);
        }
    }
}
