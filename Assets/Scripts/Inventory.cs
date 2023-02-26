using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject[] invArray;
    public bool hasPosters = false;
    public bool hasSkateboard = false;
    public bool hasDVD = false;

    public float money = 25f;
    public TextMeshProUGUI moneyText;

    public Button skateboardIcon;
    public Button posterIcon;
    public Button dvdIcon;

    void Start()
    {
        foreach (Transform child in transform)
        {
            moneyText.text = "MONEY : " + money + "$";
            child.gameObject.SetActive(false);
        }       
    }

    public void Pause()
    {
        Debug.Log("hasPosters: " + hasPosters);
        if(hasPosters)
        {
            posterIcon.gameObject.SetActive(true);
        }
        if(hasSkateboard)
        {
            skateboardIcon.gameObject.SetActive(true);
        }
        if(hasDVD)
        {
            dvdIcon.gameObject.SetActive(true);
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
    public void SkateboardGet()
    {
        Debug.Log("You got the skateboard!");
        hasSkateboard = true;      
    }


    public void OnBuy()
    {
        if(money>= 25)
        {
            FindObjectOfType<FlicksAndFlavours>().ItemBuy();
            money -= 25;
            hasDVD = true;
            Debug.Log("you got the DVD!");
        }
        else if(money < 25)
        {
            Debug.Log("You're too broke!");
            FindObjectOfType<FlicksAndFlavours>().TooBroke();
        }
    }



}
