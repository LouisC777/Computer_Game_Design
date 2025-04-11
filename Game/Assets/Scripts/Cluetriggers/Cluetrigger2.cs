using UnityEngine;
using TMPro; 
public class Cluetrigger2 : MonoBehaviour
{
    public GameObject infoBox2;              // The UI panel to show
    public TextMeshProUGUI infoText2;        // The text inside the panel
    public string clueMessage = "This is a clue."; // Editable message in inspector
    public GameObject eHint2;               

    private bool isNear = false;

    void Start()
    {
        if (infoBox2 != null) infoBox2.SetActive(false);
        if (eHint2 != null) eHint2.SetActive(false);

        Debug.Log(eHint2 != null ? "eHint�Ѹ�ֵ" : "���棺eHintδ��ֵ");
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
            
            if (eHint2 != null) eHint2.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            if (eHint2 != null) eHint2.SetActive(false);
            if (infoBox2 != null) infoBox2.SetActive(false);
        }
    }

    void ToggleInfoBox()
    {
        
        if (infoBox2 != null)
        {
            if (eHint2 != null) eHint2.SetActive(false);
            bool isActive = infoBox2.activeSelf;
            infoBox2.SetActive(!isActive);

            if (!isActive && infoText2 != null)
            {
                infoText2.text = clueMessage;
            }
        }
    }
}
