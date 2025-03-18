using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private BrickCounterUI brickCounter;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private AudioSource audioSource; // 用于播放音效的 AudioSource 组件

    // 新增：UI相关变量
    [SerializeField] private LivesUI livesUI;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;  // 游戏胜利面板

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
        // fire audio here
        // implement particle effect here
        // add camera shake here

        if (CameraShake.Instance != null)
        {
            Debug.Log("出发震动");
            CameraShake.Instance.ShakeCamera(0.2f);  // 震动强度
        }

        //if (audioSource != null)
        //{
        //    audioSource.Play();  // 使用 PlayOneShot 来播放音效
        //}
        //else
        //{
        //    Debug.LogWarning("AudioSource 组件或音效未设置！");
        //}

        AudioManager.instance.playBump();

        currentBrickCount--;
        IncreaseScore(); // 更新分数
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if(currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }

    public void KillBall()
    {
        maxLives--;

        // Add HP Manager System
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
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay

        if (currentLives <= 0)
        {
            GameOver(); // 生命值为0，游戏结束
        }
        else
        {
            ball.ResetBall();
        }
    }

    public void IncreaseScore()
    {
        score++;
        brickCounter.UpdateScore(score);
    }

    // Add GameOver
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

    // 为按钮点击处理添加这个方法
    public void HandleButtonClick(string action)
    {
        // 临时恢复时间流动以处理点击
        Time.timeScale = 1f;

        // 根据传入的操作执行不同功能
        switch (action)
        {
            case "restart":
                RestartGame();
                break;
            case "mainmenu":
                ReturnToMainMenu();
                break;
            case "quit":
                QuitGame();
                break;
        }
    }

}
