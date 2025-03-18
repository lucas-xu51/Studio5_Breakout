using UnityEngine;

public class ButtonHooks : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("click");
        SceneHandler.Instance.LoadNextScene();
<<<<<<< Updated upstream
=======
        //SceneManager.LoadScene("Level 1");
>>>>>>> Stashed changes
    }

    public void ExitToMenu()
    {
        SceneHandler.Instance.LoadMenuScene();
    }
}
