using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float fadeDuration = 2f;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    public void FadeIt()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        // Fade in
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            canvasGroup.alpha = t;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        // Fade out
        t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime / fadeDuration;
            canvasGroup.alpha = t;
            yield return null;
        }
        FindObjectOfType<PlayerController>().YesMove();
    }

}
