using UnityEngine;

public class Cluetrigger : MonoBehaviour
{
    public GameObject infoBox;  // 信息框UI元素
    private bool isNear = false;  // 是否靠近物体
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 检查玩家是否靠近并按下E键
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInfoBox();
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 假设玩家的Tag是Player
        {
            isNear = true;
            // 你可以在这里提示玩家按E键
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            // 你可以在这里隐藏提示玩家按E键
        }
    }
    void ToggleInfoBox()
    {
        infoBox.SetActive(!infoBox.activeSelf);
    }
}
