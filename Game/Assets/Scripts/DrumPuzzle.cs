using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrumPuzzleManager : MonoBehaviour
{
    [Header("音频")]
    public AudioSource audioSource;         // 用于播放节奏和鼓音效
    public AudioClip fullDrumSequence;      // 播放的节奏音频
    public AudioClip[] drumClips;           // 四个鼓音效

    [Header("按钮")]
    public Button playMusicButton;          // 播放节奏按钮
    public Button[] drumButtons;            // 四个代表鼓的按钮

    [Header("正确演奏顺序")]
    public List<int> correctSequence = new List<int>(); // 如 0,1,2,3 表示顺序

    private List<int> playerInput = new List<int>();     // 玩家输入的顺序

    [Header("UI 提示")]
    public GameObject successPanel;
    public GameObject puzzlePanel;
    public GameObject failText;

    void Start()
    {
        // 点击播放节奏按钮
        playMusicButton.onClick.AddListener(PlaySequence);

        // 点击鼓按钮：播放音效 + 记录顺序
        for (int i = 0; i < drumButtons.Length; i++)
        {
            int index = i; // 避免闭包 bug
            drumButtons[i].onClick.AddListener(() => PlayDrum(index));
        }

        playerInput.Clear();
    }

    // 播放整段节奏
    void PlaySequence()
    {
        audioSource.Stop();
        audioSource.clip = fullDrumSequence;
        audioSource.Play();
        playerInput.Clear(); // 清除旧的玩家输入
    }

    // 播放单个鼓音效，并记录玩家点击顺序
    void PlayDrum(int index)
    {
        if (index >= 0 && index < drumClips.Length)
        {
            audioSource.PlayOneShot(drumClips[index]);
            playerInput.Add(index);

            if (playerInput.Count == correctSequence.Count)
            {
                CheckAnswer();
            }
        }
    }

    // 比较玩家输入是否与正确顺序一致
    void CheckAnswer()
    {
        bool correct = true;
        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (playerInput[i] != correctSequence[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            Debug.Log("✅ 正确演奏！");
            successPanel.SetActive(true); // 显示成功面板
            puzzlePanel.SetActive(false); // 显示成功面板
                                          // 你还可以在这里播放奖励音效、动画等
        }
        else
        {
            Debug.Log("❌ 错误演奏！");
            StartCoroutine(ShowFailHint());
            playerInput.Clear();
        }
    }
    IEnumerator ShowFailHint()
    {
        failText.SetActive(true);
        yield return new WaitForSecondsRealtime(2f); // 显示 2 秒
        failText.SetActive(false);
    }
    public void CloseSuccessPanel()
    {
        if (successPanel) successPanel.SetActive(false);
        Time.timeScale = 1f; // ✅ 恢复游戏时间
    }
}
