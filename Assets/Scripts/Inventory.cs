using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] invArray;
    public bool hasPosters = false;
    public bool hasSkateboard = false;

    public Button skateboardIcon;
    public Button posterIcon;
    //public Image posterImage;

    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }       
    }
    // I need to update this so only the items you have show up.
    public void Pause()
    {
        Debug.Log("hasPosters: " + hasPosters);
        if(hasPosters)
        {
            //posterImage.gameObject.SetActive(true);
            posterIcon.gameObject.SetActive(true);
        }
        if(hasSkateboard)
        {
            skateboardIcon.gameObject.SetActive(true);
        }
        for (int i = 0; i < invArray.Length; i++) 
        {
            invArray[i].SetActive(true);
        }
    }
    public void UnPause()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void PostersGet()
    {
        Debug.Log("You got the posters!");
        hasPosters = true;
    }
}
