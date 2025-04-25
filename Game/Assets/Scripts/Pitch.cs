using UnityEngine;
using TMPro;

public class PitchGuessPuzzle : MonoBehaviour
{
    public TMP_InputField guessInputField;      // TextMeshPro 输入框
    public TextMeshProUGUI feedbackText;        // TextMeshPro 文本
    public GameObject puzzlePanel;              // 当前猜音高的界面
    public GameObject successPanel;             // 成功界面

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

                Time.timeScale = 1f; // ✅ 恢复时间

                puzzlePanel.SetActive(false);   // ✅ 关闭当前界面
                successPanel.SetActive(true);   // ✅ 打开成功界面
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
