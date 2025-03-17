using UnityEngine;
using UnityEngine.SceneManagement; // ���SceneManagement�����ռ�

public class ButtonHooks : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("click");
        //SceneHandler.Instance.LoadNextScene();
        SceneManager.LoadScene("Level 1");
    }

    public void ExitToMenu()
    {
        SceneHandler.Instance.LoadMenuScene();
    }
}
