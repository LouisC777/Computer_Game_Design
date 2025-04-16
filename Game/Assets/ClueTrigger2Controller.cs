using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClueTrigger2Controller : MonoBehaviour
{
    public GameObject eHintText2;     // "Press E!" のTextMeshProテキスト
    public GameObject HintPaper2;     // ヒントPNG画像 (Image)

    private bool isNear = false;

    void Start()
    {
        if (eHintText2 != null) eHintText2.SetActive(false);
        if (HintPaper2 != null) HintPaper2.SetActive(false);
    }

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            bool isHintActive = HintPaper2.activeSelf;
            HintPaper2.SetActive(!isHintActive);
            if (eHintText2 != null) eHintText2.SetActive(isHintActive == false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            if (eHintText2 != null) eHintText2.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            if (eHintText2 != null) eHintText2.SetActive(false);
            if (HintPaper2 != null) HintPaper2.SetActive(false);
        }
    }
}
