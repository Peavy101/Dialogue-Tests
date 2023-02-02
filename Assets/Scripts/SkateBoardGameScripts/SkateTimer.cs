using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateTimer : MonoBehaviour
{
    private float startTime;
    private Vector3 startScale;
    private Vector3 targetScale = new Vector3(1, 0, 1);

    void Start()
    {
        startTime = Time.time;
        startScale = transform.localScale;
    }

    void Update()
    {
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
        float t = Mathf.Clamp01(timeElapsed / 5.0f);

        transform.localScale = Vector3.Lerp(startScale, targetScale, t);
    }
}
