using UnityEngine;
using UnityEngine.UI;

public class ClueTrigger : MonoBehaviour
{
    public GameObject clueUI;
    public string clueText;

    private bool isPlayerInRange;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            clueUI.SetActive(true);
            clueUI.GetComponentInChildren<Text>().text = clueText;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            clueUI.SetActive(false);
        }
    }
}
