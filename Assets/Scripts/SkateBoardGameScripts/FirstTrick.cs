using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstTrick : MonoBehaviour
{
    private float startTime;
    private int wCount = 0;
    private bool hasPressedSpace = false;
    private bool trickCompleted = false;

    public Image ollieWOne;
    public Image ollieWTwo;
    public Image ollieWThree;
    public Image ollieSpace;

    public TextMeshProUGUI gameText;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        VisualResponse();
        float currentTime = Time.time;
        if (currentTime - startTime < 5.0f && !trickCompleted)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                wCount++;
            }
            else if (wCount == 3 && Input.GetKeyDown(KeyCode.Space))
            {
                hasPressedSpace = true;
            }
            else if (Input.anyKeyDown)
            {
                wCount = 0;
                hasPressedSpace = false;
            }

            if (wCount == 3 && hasPressedSpace)
            {
                Debug.Log("Player has input the correct sequence.");
                gameText.text = ("You got it!");
                FindObjectOfType<SkaterBoy>().Ollie();
                trickCompleted = true;
            }
        }
        else if (!trickCompleted)
        {
            Debug.Log("Player has failed to input the correct sequence.");
            gameText.text = ("Ooh too bad! Try Again!");
            trickCompleted = true;
        }
    }

    private void VisualResponse()
    {
        if(wCount == 0)
        {
            ollieWOne.enabled = true;
            ollieWTwo.enabled = true;
            ollieWThree.enabled = true;
            ollieSpace.enabled = true;
        }
        if(wCount == 1)
        {
            ollieWOne.enabled = false;
        }
        if(wCount == 2)
        {
            ollieWTwo.enabled = false;
        }
        if(wCount == 3)
        {
            ollieWThree.enabled = false;
        }
        if(hasPressedSpace)
        {
            ollieSpace.enabled = false;
        }
    }




}

