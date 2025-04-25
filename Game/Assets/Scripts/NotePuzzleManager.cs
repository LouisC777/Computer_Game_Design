using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class NotePuzzleManager : MonoBehaviour
{
    public AudioSource audioSource;             // 播放音符的 AudioSource
    public AudioClip noteC;
    public AudioClip noteE;
    public AudioClip noteG;

    public GameObject successPanel;             // 成功提示面板
    public TextMeshProUGUI feedbackText;                   // 可选提示文字

    private List<string> inputSequence = new List<string>();
    private string[] correctSequence = { "C", "E", "G", "C" };

    public void PlayNote(string note)
    {
        switch (note)
        {
            case "C":
                audioSource.PlayOneShot(noteC);
                break;
            case "E":
                audioSource.PlayOneShot(noteE);
                break;
            case "G":
                audioSource.PlayOneShot(noteG);
                break;
        }

        inputSequence.Add(note);
        CheckSequence();
    }

    void CheckSequence()
    {
        if (inputSequence.Count < correctSequence.Length)
            return;

        bool isCorrect = true;
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (inputSequence[i] != correctSequence[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            feedbackText.text = "🎉 Correct sequence!";
            successPanel.SetActive(true);
        }
        else
        {
            feedbackText.text = "❌ Wrong sequence. Try again.";
        }

        inputSequence.Clear(); // 重置输入
    }
}
