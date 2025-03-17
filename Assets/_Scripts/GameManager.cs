using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private AudioSource audioSource;

    // UI相关变量
    [SerializeField] private LivesUI livesUI;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;  // 新增：游戏胜利面板

    private int currentLives;
    private int currentBrickCount;
    private int totalBrickCount;

    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;

        // 初始化生命值
        currentLives = maxLives;
        Debug.Log($"OnEnable: setting currentLives to {currentLives}");

        // 初始化生命值UI
        if (livesUI != null)
        {
            livesUI.InitializeLives(maxLives);
            livesUI.UpdateLives(currentLives);
        }
        else
        {
            Debug.LogError("LivesUI reference is missing in GameManager");
        }

        // 确保游戏开始时游戏结束面板和胜利面板是隐藏的
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(false);
        }

        // 确保游戏开始时时间尺度正常
        Time.timeScale = 1f;

        // 解锁鼠标控制
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        if (CameraShake.Instance != null)
        {
            Debug.Log("触发震动");
            CameraShake.Instance.ShakeCamera(0.2f);
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource 组件或音效未设置！");
        }

        currentBrickCount--;
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");

        // 当所有砖块都被销毁时
        if (currentBrickCount == 0)
        {
            // 获取当前场景名称
            string currentSceneName = SceneManager.GetActiveScene().name;

            // 根据场景名称执行不同操作
            if (currentSceneName == "Level 1")
            {
                Debug.Log("Level 1 完成，加载 Level 2");
                SceneManager.LoadScene("Level 2");
            }
            else if (currentSceneName == "Level 2")
            {
                Debug.Log("Level 2 完成，回到主菜单");
                ReturnToMainMenu();
            }
            else
            {
                // 如果场景名称不是Level 1或Level 2，尝试加载下一个场景
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    // 如果没有下一个场景，显示游戏胜利
                    ShowGameWin();
                }
            }
        }
    }

    public void KillBall()
    {
        currentLives--;
        Debug.Log($"KillBall called, currentLives now: {currentLives}");

        // 更新生命值UI并播放动画
        if (livesUI != null)
        {
            livesUI.AnimateLoseLife(currentLives);
            livesUI.UpdateLives(currentLives);
        }
        else
        {
            Debug.LogError("LivesUI reference is missing in KillBall");
        }

        if (currentLives <= 0)
        {
            GameOver(); // 生命值为0，游戏结束
        }
        else
        {
            ball.ResetBall();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 暂停游戏
        Time.timeScale = 0f;

        // 解锁鼠标以便玩家可以点击按钮
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // 新增：显示游戏胜利面板
    private void ShowGameWin()
    {
        Debug.Log("Game Win!");
        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("游戏胜利面板未设置！");
        }

        // 暂停游戏
        Time.timeScale = 0f;

        // 解锁鼠标以便玩家可以点击按钮
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // 重新开始游戏
    public void RestartGame()
    {
        // 重置游戏状态
        Time.timeScale = 1f;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(false);
        }

        // 使用SceneManager直接重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 返回主菜单
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // 退出游戏
    public void QuitGame()
    {
#if UNITY_EDITOR
            // 如果在Unity编辑器中运行，则停止播放模式
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 如果是构建的应用程序，则退出应用
        Application.Quit();
#endif

        Debug.Log("退出游戏");
    }
}