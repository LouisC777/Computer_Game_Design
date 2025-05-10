using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Collections;

public class RoomLightController : MonoBehaviour
{
    public Light2D roomLight;
    public float lightDuration = 3f;  // 点灯時間
    public float cooldown = 6f;       // クールダウン

    public TextMeshProUGUI cooldownText; // UI表示用Text

    private bool canUseLight = true;

    void Start()
    {
        if (roomLight != null)
        {
            roomLight.enabled = false;
            Debug.Log("RoomLight initially OFF");
        }

        if (cooldownText != null)
        {
            cooldownText.text = ""; // 最初は空白に
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (canUseLight)
            {
                Debug.Log("L key pressed — activating room light");
                StartCoroutine(EnableRoomLight());
            }
            else
            {
                Debug.Log("クールダウン中だよ！");
                ShowCooldownMessage();
            }
        }
    }

    private IEnumerator EnableRoomLight()
    {
        canUseLight = false;

        if (roomLight != null)
        {
            roomLight.enabled = true;
            Debug.Log("ライト ON");
        }

        yield return new WaitForSeconds(lightDuration);

        if (roomLight != null)
        {
            roomLight.enabled = false;
            Debug.Log("ライト OFF");
        }

        Debug.Log("クールダウン中...");
        yield return new WaitForSeconds(cooldown);

        canUseLight = true;
        Debug.Log("ライト再使用可能になりました");
    }

    void ShowCooldownMessage()
    {
        if (cooldownText != null)
        {
            cooldownText.text = "Light cooling down... Try again in 5 seconds.";
            CancelInvoke(nameof(HideCooldownMessage)); // 連打対策
            Invoke(nameof(HideCooldownMessage), 2f);    // 2秒後に消す
        }
    }

    void HideCooldownMessage()
    {
        if (cooldownText != null)
        {
            cooldownText.text = "";
        }
    }
}
