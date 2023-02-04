using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkateTimer : MonoBehaviour
{
    private float startTime;
    private Vector3 startScale;
    private Vector3 targetScale = new Vector3(1, 0, 1);

    private bool startTimer = false;

    Image timerImage;

    void Start()
    {
        timerImage = GetComponent<Image>();
    }

    void Update()
    {
        if(startTimer)
        {
            RectTransform rectTransform = timerImage.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(1, 1, 1);
            Timer();
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        startScale = transform.localScale;
        startTimer = true;
    }
    void Timer()
    {
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
        float t = Mathf.Clamp01(timeElapsed / 5.0f);

        transform.localScale = Vector3.Lerp(startScale, targetScale, t);
    }

    public void StopTimer()
    {
        startTimer = false;
    }
}
