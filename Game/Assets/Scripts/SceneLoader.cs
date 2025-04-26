using UnityEngine;
using UnityEngine.SceneManagement; // 导入场景管理命名空间

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // 要跳转的场景名称

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
