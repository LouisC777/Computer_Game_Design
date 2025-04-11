using UnityEngine;
using TMPro;  // Make sure you're using TextMeshPro

public class Cluetrigger : MonoBehaviour
{
    public GameObject infoBox1;              // The UI panel to show
    public TextMeshProUGUI infoText1;        // The text inside the panel
    public string clueMessage = "This is a clue."; // Editable message in inspector
    public GameObject eHint1;                // Optional: hint like "Press E"

    private bool isNear = false;

    void Start()
    {
        if (infoBox1 != null) infoBox1.SetActive(false);
        if (eHint1 != null) eHint1.SetActive(false);

        Debug.Log(eHint1 != null ? "eHint�Ѹ�ֵ" : "���棺eHintδ��ֵ");
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
            if (infoBox1 != null) infoBox1.SetActive(false);
        }
    }

    void ToggleInfoBox()
    {
        
        if (infoBox1 != null)
        {
            if (eHint1 != null) eHint1.SetActive(false);
            bool isActive = infoBox1.activeSelf;
            infoBox1.SetActive(!isActive);

            if (!isActive && infoText1 != null)
            {
                infoText1.text = clueMessage;
            }
        }
    }
}
