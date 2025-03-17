using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
public class BrickCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform brickTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;
    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = brickTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        // set the score to the masked text UI
        toUpdate.SetText($"{score}");
        // trigger the local move animation
        brickTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        // this is how you start a coroutine
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score)
    {
        // this tells the editor to wait for a given period of time
        yield return new WaitForSeconds(duration);
        // we use duration since that's the same time as the animation
        current.SetText($"{score}"); // update the original score
        Vector3 localPosition = brickTextContainer.localPosition;
        brickTextContainer.localPosition = new Vector3(localPosition.x,
        containerInitPosition, localPosition.z);
        // then reset the y-localPosition of the coinTextContainer
    }
}