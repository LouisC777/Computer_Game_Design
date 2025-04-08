using UnityEngine;

public class Cluetrigger : MonoBehaviour
{
    public GameObject infoBox;  // ��Ϣ��UIԪ��
    private bool isNear = false;  // �Ƿ񿿽�����
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������Ƿ񿿽�������E��
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInfoBox();
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ������ҵ�Tag��Player
        {
            isNear = true;
            // �������������ʾ��Ұ�E��
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            // �����������������ʾ��Ұ�E��
        }
    }
    void ToggleInfoBox()
    {
        infoBox.SetActive(!infoBox.activeSelf);
    }
}
