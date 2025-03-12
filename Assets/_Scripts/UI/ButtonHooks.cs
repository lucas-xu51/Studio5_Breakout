using UnityEngine;

public class ButtonHooks : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("here");
        SceneHandler.Instance.LoadNextScene();
    }

    public void ExitToMenu()
    {
        SceneHandler.Instance.LoadMenuScene();
    }
}
