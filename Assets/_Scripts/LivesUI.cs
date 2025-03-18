using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;  // 心形图标预制体
    [SerializeField] private Transform heartsContainer;  // 用于放置心形图标的容器
    [SerializeField] private bool reduceFromRight = true; // 控制从右边开始减少生命值
    [SerializeField] private float spacing = 20f; // 心形之间的间距
    [SerializeField] private float leftPadding = 50f; // 左侧边距

    private GameObject[] hearts;  // 存储所有心形图标引用

    // 初始化生命值UI
    public void InitializeLives(int maxLives)
    {
        Debug.Log($"InitializeLives called with maxLives: {maxLives}");

        // 清除现有的心形图标
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }

        // 创建新的心形图标
        hearts = new GameObject[maxLives];
        for (int i = 0; i < maxLives; i++)
        {
            hearts[i] = Instantiate(heartPrefab, heartsContainer);

            // 设置心形的位置，确保它们保持固定位置
            RectTransform rectTransform = hearts[i].GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // 禁用RectTransform的Layout Element影响
                LayoutElement layoutElement = hearts[i].GetComponent<LayoutElement>();
                if (layoutElement == null)
                {
                    layoutElement = hearts[i].AddComponent<LayoutElement>();
                }
                layoutElement.ignoreLayout = true;

                float heartWidth = rectTransform.rect.width;
                // 固定位置，根据从左到右或从右到左排列
                float xPos;
                if (reduceFromRight)
                {
                    // 从右到左，从左边距开始
                    xPos = leftPadding + (maxLives - 1 - i) * (heartWidth + spacing);
                }
                else
                {
                    // 从左到右，从左边距开始
                    xPos = leftPadding + i * (heartWidth + spacing);
                }

                rectTransform.anchoredPosition = new Vector2(xPos, 0);

                // 设置锚点为左中
                rectTransform.anchorMin = new Vector2(0, 0.5f);
                rectTransform.anchorMax = new Vector2(0, 0.5f);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }

    // 更新生命值UI
    public void UpdateLives(int currentLives)
    {
        Debug.Log($"UpdateLives called with currentLives: {currentLives}");

        // 确保不超出数组范围
        if (hearts == null)
        {
            Debug.LogError("Hearts array is null in UpdateLives");
            return;
        }

        // 根据当前生命值显示或隐藏心形图标
        int maxLives = hearts.Length;
        for (int i = 0; i < maxLives; i++)
        {
            bool shouldBeActive;

            if (reduceFromRight)
            {
                // 从右边开始减少：当前生命值大于(最大生命值-i-1)时显示
                shouldBeActive = currentLives > (maxLives - i - 1);
            }
            else
            {
                // 从左边开始减少：当前生命值大于i时显示
                shouldBeActive = currentLives > i;
            }

            hearts[i].SetActive(shouldBeActive);
        }
    }

    // 为失去生命添加动画
    public void AnimateLoseLife(int currentLives)
    {
        Debug.Log($"AnimateLoseLife called with currentLives: {currentLives}");

        // 确保不超出数组范围
        if (hearts == null)
        {
            Debug.LogError("Hearts array is null in AnimateLoseLife");
            return;
        }

        // 计算要动画的心形索引 (刚失去的那颗心)
        int heartToAnimate;

        if (reduceFromRight)
        {
            // 从右边开始减少：动画索引是最大生命值-当前生命值-1
            heartToAnimate = hearts.Length - currentLives - 1;
        }
        else
        {
            // 从左边开始减少：动画索引是当前生命值
            heartToAnimate = currentLives;
        }

        if (heartToAnimate >= 0 && heartToAnimate < hearts.Length)
        {
            StartCoroutine(ScaleDownAndHide(hearts[heartToAnimate]));
        }
    }

    private IEnumerator ScaleDownAndHide(GameObject heart)
    {
        float duration = 0.5f;
        float elapsed = 0;
        Vector3 originalScale = heart.transform.localScale;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            heart.transform.localScale = originalScale * (1 - t);

            yield return null;
        }

        heart.SetActive(false);
        // 重置缩放，以便下次游戏开始时正常显示
        heart.transform.localScale = originalScale;
    }
}