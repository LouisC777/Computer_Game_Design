using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public int currentClue = 0;

    public bool CanAccessClue(int clueIndex)
    {
        return clueIndex == currentClue;
    }

    public void AdvanceClue()
    {
        currentClue++;
    }
}
