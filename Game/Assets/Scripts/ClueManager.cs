using UnityEngine;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public int totalClues = 4;
    private bool[] unlockedClues;

    void Awake()
    {
        unlockedClues = new bool[totalClues];
        unlockedClues[0] = true; // Clue 0 (first clue) is unlocked by default
    }

    public bool IsClueUnlocked(int clueIndex)
    {
        if (clueIndex < 0 || clueIndex >= unlockedClues.Length)
            return false;

        return unlockedClues[clueIndex];
    }

    public bool CanAccessClue(int clueIndex)
    {
        // A clue can be accessed if it's already unlocked or it's the next one to unlock
        return IsClueUnlocked(clueIndex) || clueIndex == GetNextUnlockableClue();
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
