using UnityEngine;
using UnityEngine.SceneManagement; // ���볡�����������ռ�

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Ҫ��ת�ĳ�������

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
