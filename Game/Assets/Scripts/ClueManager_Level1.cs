using UnityEngine;
using UnityEngine.Tilemaps;

public class ClueManager_Level1 : MonoBehaviour
{
    public int totalClues = 5;                    // 总线索数量
    private bool[] unlockedClues;                  // 线索解锁状态数组

    [Header("门相关")]
    public PuzzleManager puzzleManager;            // 引用PuzzleManager（控制开门）
    public int clueIndexToOpenDoor = 3;             // 解锁到第几个线索时开门（第4个线索，index是3）

    void Awake()
    {
        unlockedClues = new bool[totalClues];
        for (int i = 0; i < unlockedClues.Length; i++)
        {
            unlockedClues[i] = false;
        }
    }

    public bool IsClueUnlocked(int clueIndex)
    {
        if (clueIndex < 0 || clueIndex >= unlockedClues.Length)
            return false;

        return unlockedClues[clueIndex];
    }

    public bool IsClueNextToUnlock(int clueIndex)
    {
        return clueIndex == GetNextUnlockableClue();
    }

    public bool CanAccessClue(int clueIndex)
    {
        return IsClueUnlocked(clueIndex) || IsClueNextToUnlock(clueIndex);
    }

    public void UnlockClue(int clueIndex)
    {
        if (clueIndex >= 0 && clueIndex < unlockedClues.Length)
        {
            unlockedClues[clueIndex] = true;

            // 🔥 特别逻辑：当解锁到设定的线索时开门
            if (clueIndex == clueIndexToOpenDoor && puzzleManager != null)
            {
                Debug.Log("解锁到第4个线索，厕所门打开！");
                puzzleManager.OnPuzzleSolved();
            }
        }
    }

    private int GetNextUnlockableClue()
    {
        for (int i = 0; i < unlockedClues.Length; i++)
        {
            if (!unlockedClues[i])
                return i;
        }
        return unlockedClues.Length; // 全部线索已解锁
    }
}
