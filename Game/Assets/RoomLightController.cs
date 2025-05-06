using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class RoomLightController : MonoBehaviour
{
    public Light2D roomLight;
    public float lightDuration = 10f;
    public float cooldown = 10f;

    private bool canUseLight = true;

    void Start()
    {
        if (roomLight != null)
        {
            roomLight.enabled = false;
            Debug.Log("RoomLight initially OFF");
        }
        else
        {
            Debug.LogError("roomLight is not assigned!");
        }
    }

    void Update()
    {
        Debug.Log("Update is running");

        if (Input.GetKeyDown(KeyCode.L) && canUseLight)
        {
            Debug.Log("L key pressed — activating room light");
            StartCoroutine(EnableRoomLight());
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
}
