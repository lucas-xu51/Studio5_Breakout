using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;  // ����ͼ��Ԥ����
    [SerializeField] private Transform heartsContainer;  // ���ڷ�������ͼ�������
    [SerializeField] private bool reduceFromRight = true; // ���ƴ��ұ߿�ʼ��������ֵ
    [SerializeField] private float spacing = 20f; // ����֮��ļ��
    [SerializeField] private float leftPadding = 50f; // ���߾�

    private GameObject[] hearts;  // �洢��������ͼ������

    // ��ʼ������ֵUI
    public void InitializeLives(int maxLives)
    {
        Debug.Log($"InitializeLives called with maxLives: {maxLives}");

        // ������е�����ͼ��
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }

        // �����µ�����ͼ��
        hearts = new GameObject[maxLives];
        for (int i = 0; i < maxLives; i++)
        {
            hearts[i] = Instantiate(heartPrefab, heartsContainer);

            // �������ε�λ�ã�ȷ�����Ǳ��̶ֹ�λ��
            RectTransform rectTransform = hearts[i].GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // ����RectTransform��Layout ElementӰ��
                LayoutElement layoutElement = hearts[i].GetComponent<LayoutElement>();
                if (layoutElement == null)
                {
                    layoutElement = hearts[i].AddComponent<LayoutElement>();
                }
                layoutElement.ignoreLayout = true;

                float heartWidth = rectTransform.rect.width;
                // �̶�λ�ã����ݴ����һ���ҵ�������
                float xPos;
                if (reduceFromRight)
                {
                    // ���ҵ��󣬴���߾࿪ʼ
                    xPos = leftPadding + (maxLives - 1 - i) * (heartWidth + spacing);
                }
                else
                {
                    // �����ң�����߾࿪ʼ
                    xPos = leftPadding + i * (heartWidth + spacing);
                }

                rectTransform.anchoredPosition = new Vector2(xPos, 0);

                // ����ê��Ϊ����
                rectTransform.anchorMin = new Vector2(0, 0.5f);
                rectTransform.anchorMax = new Vector2(0, 0.5f);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }

    // ��������ֵUI
    public void UpdateLives(int currentLives)
    {
        Debug.Log($"UpdateLives called with currentLives: {currentLives}");

        // ȷ�����������鷶Χ
        if (hearts == null)
        {
            Debug.LogError("Hearts array is null in UpdateLives");
            return;
        }

        // ���ݵ�ǰ����ֵ��ʾ����������ͼ��
        int maxLives = hearts.Length;
        for (int i = 0; i < maxLives; i++)
        {
            bool shouldBeActive;

            if (reduceFromRight)
            {
                // ���ұ߿�ʼ���٣���ǰ����ֵ����(�������ֵ-i-1)ʱ��ʾ
                shouldBeActive = currentLives > (maxLives - i - 1);
            }
            else
            {
                // ����߿�ʼ���٣���ǰ����ֵ����iʱ��ʾ
                shouldBeActive = currentLives > i;
            }

            hearts[i].SetActive(shouldBeActive);
        }
    }

    // Ϊʧȥ������Ӷ���
    public void AnimateLoseLife(int currentLives)
    {
        Debug.Log($"AnimateLoseLife called with currentLives: {currentLives}");

        // ȷ�����������鷶Χ
        if (hearts == null)
        {
            Debug.LogError("Hearts array is null in AnimateLoseLife");
            return;
        }

        // ����Ҫ�������������� (��ʧȥ���ǿ���)
        int heartToAnimate;

        if (reduceFromRight)
        {
            // ���ұ߿�ʼ���٣������������������ֵ-��ǰ����ֵ-1
            heartToAnimate = hearts.Length - currentLives - 1;
        }
        else
        {
            // ����߿�ʼ���٣����������ǵ�ǰ����ֵ
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
        // �������ţ��Ա��´���Ϸ��ʼʱ������ʾ
        heart.transform.localScale = originalScale;
    }
}