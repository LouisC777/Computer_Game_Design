using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClueTrigger1Controller : MonoBehaviour
{
    public GameObject eHintText1;     // "Press E!" のTextMeshProテキスト
    public GameObject HintPaper1;     // ヒントPNG画像 (Image)

    private bool isNear = false;

    void Start()
    {
        if (eHintText1 != null) eHintText1.SetActive(false);
        if (HintPaper1 != null) HintPaper1.SetActive(false);
    }

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            // ヒントをトグルで表示/非表示
            bool isHintActive = HintPaper1.activeSelf;
            HintPaper1.SetActive(!isHintActive);

            // Press E テキストはヒント表示中は非表示
            if (eHintText1 != null) eHintText1.SetActive(isHintActive == false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            if (eHintText1 != null) eHintText1.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            if (eHintText1 != null) eHintText1.SetActive(false);
            if (HintPaper1 != null) HintPaper1.SetActive(false);
        }
    }
}
