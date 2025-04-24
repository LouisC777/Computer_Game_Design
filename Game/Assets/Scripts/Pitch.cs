using UnityEngine;
using TMPro;

public class PitchGuessPuzzle : MonoBehaviour
{
    public TMP_InputField guessInputField;      // TextMeshPro 输入框
    public TextMeshProUGUI feedbackText;        // TextMeshPro 文本
    public GameObject successPanel;

    private int correctPitch = 440;

    public void OnConfirmGuess()
    {
        string input = guessInputField.text;
        int guess;

        if (int.TryParse(input, out guess))
        {
            if (guess == correctPitch)
            {
                feedbackText.text = "🎉 Congratulations! You got it right!";
                successPanel.SetActive(true);
            }
            else if (guess < 400)
            {
                feedbackText.text = "Too low.";
            }
            else if (guess >= 400 && guess < 440)
            {
                feedbackText.text = "A bit too low.";
            }
            else if (guess > 440 && guess <= 500)
            {
                feedbackText.text = "A bit too high.";
            }
            else if (guess > 500)
            {
                feedbackText.text = "Too high.";
            }
        }
        else
        {
            feedbackText.text = "Please enter a valid number.";
        }
    }

}
