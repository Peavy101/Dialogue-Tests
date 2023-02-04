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
    private bool trickStart = false;

    public Image ollieWOne;
    public Image ollieWTwo;
    public Image ollieWThree;
    public Image ollieSpace;

    public TextMeshProUGUI gameText;
    public TextMeshProUGUI countdownText;

    void Start()
    {
    }

    void Update()
    {
        if(trickStart)
        {
            FirstVisualResponse();
            FirstChallenge();
        }
    }

    private void FirstVisualResponse()
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

    private void FirstChallenge()
    {
        float currentTime = Time.time;
        float elapsedTime = currentTime - startTime;
        int countdown = 5 - (int)elapsedTime;
        if (currentTime - startTime < 5.0f && !trickCompleted)
        {
            countdownText.text = countdown.ToString();
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
            else if (wCount == 4)
            {
                wCount = 0;
            }
            else if (Input.anyKeyDown && Input.inputString != "W" && Input.inputString != " ")
            {   
                wCount = 0;
                hasPressedSpace = false;
            }
            if (wCount == 3 && hasPressedSpace)//success
            {
                Debug.Log("Player has input the correct sequence.");
                gameText.text = ("You got it!");
                FindObjectOfType<SkateTimer>().StopTimer();
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

    public void TrickStart()
    {
        startTime = Time.time;
        trickStart = true;
    }

}

