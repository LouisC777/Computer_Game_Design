using UnityEngine;
using UnityEngine.UI;

public class TutorialSlideManager : MonoBehaviour
{
    public Image slideImage;             // UI Image to show current slide
    public Sprite[] slideSprites;        // Slides (PNG/JPG images)
    public Button nextButton;            // UI Next button
    public AudioSource sfxPlayer;        // AudioSource for sound
    public AudioClip slideSFX;           // Sound when switching slides

    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(ShowNextSlide);
        ShowSlide();
    }

    void ShowSlide()
    {
        slideImage.sprite = slideSprites[currentIndex];
        slideImage.canvasRenderer.SetAlpha(0f);
        slideImage.CrossFadeAlpha(1f, 0.5f, false);

        if (slideSFX != null && sfxPlayer != null)
            sfxPlayer.PlayOneShot(slideSFX);
    }

    public void ShowNextSlide()
    {
        currentIndex++;
        if (currentIndex < slideSprites.Length)
        {
            ShowSlide();
        }
        else
        {
            // End of slides – hide UI or transition into gameplay
            slideImage.CrossFadeAlpha(0f, 0.5f, false);
            nextButton.gameObject.SetActive(false);
            gameObject.SetActive(false); // Or disable entire tutorial manager
        }
    }
}
