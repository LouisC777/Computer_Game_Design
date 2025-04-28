using UnityEngine;
using TMPro; // ←パスワードを表示するならこれが必要！（TextMeshPro用）

public class ClueTrigger : MonoBehaviour
{
    public int clueIndex;                         // 0 = Clue 1, 1 = Clue 2, etc.
    public Sprite[] clueSprites;
    public ClueImageViewer clueViewer;
    public ClueManager clueManager;
    public GameObject cluePrompt;

    // ★ここを追加！！
    public TextMeshProUGUI passwordDisplay;
    public string passwordPiece;

    private bool playerInZone = false;

    void Start()
    {
        cluePrompt.SetActive(false);

        // 最初はパスワード表示を空にしておきたい場合はここに書ける
        // passwordDisplay.text = "";
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (clueManager.CanAccessClue(clueIndex))
            {
                clueViewer.ShowClue(clueSprites);
                clueManager.UnlockClue(clueIndex);
                cluePrompt.SetActive(false);

                // ★ここでパスワードを表示する
                passwordDisplay.text += passwordPiece;
            }
            else
            {
                Debug.Log("You need to find the previous clue first.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;

            if (clueManager.CanAccessClue(clueIndex))
            {
                cluePrompt.SetActive(true);
            }
            else
            {
                cluePrompt.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            cluePrompt.SetActive(false);
        }
    }
}
