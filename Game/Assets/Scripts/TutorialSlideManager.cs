using UnityEngine;
using UnityEngine.UI;

public class TutorialSlideManager : MonoBehaviour
{
    public Image slideImage;             // UI Image to show slides
    public Sprite[] slideSprites;        // Your slide images (as Sprites)
    public Button nextButton;            // "Next" button
    public AudioSource sfxPlayer;        // Optional AudioSource
    public AudioClip slideSFX;           // Optional sound clip

    private int currentIndex = 0;

    void Start()
    {
        if (slideSprites == null || slideSprites.Length == 0)
        {
            Debug.LogWarning("No slides assigned.");
            return;
        }

        nextButton.onClick.AddListener(OnNextClicked);
        ShowSlide(currentIndex);
    }

    void ShowSlide(int index)
    {
        if (index >= 0 && index < slideSprites.Length)
        {
            slideImage.sprite = slideSprites[index];
            slideImage.canvasRenderer.SetAlpha(0f);
            slideImage.CrossFadeAlpha(1f, 0.5f, false);

            if (sfxPlayer && slideSFX)
                sfxPlayer.PlayOneShot(slideSFX);

            Debug.Log("Showing slide index: " + index);
        }
        else
        {
            Debug.LogWarning("Slide index out of range: " + index);
        }
    }

    void OnNextClicked()
    {
        currentIndex++;

        if (currentIndex < slideSprites.Length)
        {
            ShowSlide(currentIndex); // ✅ Show next slide normally
        }
        else
        {
            // ✅ All slides done
            Debug.Log("Tutorial complete.");
            slideImage.CrossFadeAlpha(0f, 0.5f, false);
            nextButton.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
