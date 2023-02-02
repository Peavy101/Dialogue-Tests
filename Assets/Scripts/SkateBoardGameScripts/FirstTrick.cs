using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstTrick : MonoBehaviour
{
    private float startTime;
    private int wCount = 0;
    private bool hasPressedSpace = false;
    private bool trickCompleted = false;
    private Animator animator;

    public TextMeshProUGUI gameText;

    void Start()
    {
        startTime = Time.time;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float currentTime = Time.time;
        if (currentTime - startTime < 5.0f && !trickCompleted)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                wCount++;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                hasPressedSpace = true;
            }
        }
        else
        {
            if (wCount == 3 && hasPressedSpace && !trickCompleted)
            {
                Debug.Log("Player has input the correct sequence.");
                gameText.text = ("You got it!");
                animator.SetTrigger("Ollie");
                trickCompleted = true;
            }
            else if(!trickCompleted)
            {
                Debug.Log("Player has failed to input the correct sequence.");
                gameText.text = ("Ooh too bad! Try Again!");
                trickCompleted = true;
            }
        }
    }
}
