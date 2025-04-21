using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public int totalClues = 5;
    private bool[] unlockedClues;

    void Awake()
    {
        unlockedClues = new bool[totalClues];
        unlockedClues[0] = false; // NONE are unlocked by default
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
        }
    }

    private int GetNextUnlockableClue()
    {
        for (int i = 0; i < unlockedClues.Length; i++)
        {
            if (!unlockedClues[i])
                return i;
        }
        return unlockedClues.Length; // All clues unlocked
    }
}
