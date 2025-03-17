using UnityEngine;
using UnityEngine.Audio;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private AudioSource audioSource; // 用于播放音效的 AudioSource 组件
    [SerializeField] private ScoreManager scoreManager; // 添加计分管理器引用

    private int currentBrickCount;
    private int totalBrickCount;

    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
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

        if (audioSource != null)
        {
            audioSource.Play();  // 使用 PlayOneShot 来播放音效
        }
        else
        {
            Debug.LogWarning("AudioSource 组件或音效未设置！");
        }

        currentBrickCount--;
        scoreManager.AddScore(1); // 每个砖块加1分
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if(currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }

    public void KillBall()
    {
        maxLives--;
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay
        ball.ResetBall();
    }
}
