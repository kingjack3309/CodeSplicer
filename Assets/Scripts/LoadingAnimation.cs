using System.Collections;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{

    private RectTransform rectTransform;
    private float moveSpeed = 5;
    private float timeTillReverse = 2;
    private bool coroutinePlaying;
    private Vector2 theTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        theTransform = rectTransform.anchoredPosition;
    }

    private void Awake()
    {
        if (theTransform != Vector2.zero)
        {
            rectTransform.anchoredPosition = theTransform;
        }
    }

    private void Update()
    {
        if (!coroutinePlaying)
        {
            StartCoroutine(MaskBobAnimation());
        }
    }

    IEnumerator MaskBobAnimation()
    {
        coroutinePlaying = true;
        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
        yield return new WaitForSeconds(timeTillReverse);
        rectTransform.anchoredPosition += Vector2.down * moveSpeed * Time.deltaTime;
        yield return new WaitForSeconds(timeTillReverse);
        coroutinePlaying = false;
    }
}
