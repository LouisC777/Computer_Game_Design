using UnityEngine;
using UnityEngine.UI;

public class ClueImageViewer : MonoBehaviour
{
    public Image clueImage;
    public GameObject clueViewerUI;
    public Button nextButton;
    public Button closeButton;

    private Sprite[] currentClueSprites;
    private int currentIndex = 0;

    void Start()
    {
        clueViewerUI.SetActive(false);
        nextButton.onClick.AddListener(NextImage);
        closeButton.onClick.AddListener(CloseClue);
    }

    public void ShowClue(Sprite[] clueSprites)
    {
        if (clueSprites.Length == 0) return;

        currentClueSprites = clueSprites;
        currentIndex = 0;
        clueImage.sprite = currentClueSprites[currentIndex];
        clueViewerUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextImage()
    {
        currentIndex++;
        if (currentIndex < currentClueSprites.Length)
        {
            clueImage.sprite = currentClueSprites[currentIndex];
        }
        else
        {
            CloseClue();
        }
    }

    public void CloseClue()
    {
        clueViewerUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
