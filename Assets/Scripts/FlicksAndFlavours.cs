using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlicksAndFlavours : MonoBehaviour
{
    public TextMeshProUGUI shopText;
    public TextMeshProUGUI buttonOneText;

    bool optionOneBought = false;


    public float IncrediblesCost = 25f;
    public float HighSchoolMusicalCost = 10f;


    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }   
    }

    public void ShopTalk()
    {
        FindObjectOfType<PlayerController>().NoMove();
        shopText.text = "How can I help you?";
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }  
    }
    public void ShopNoTalk()
    {
        FindObjectOfType<PlayerController>().YesMove();
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }  
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void ItemBuy()
    {
        if(!optionOneBought)
        {
            shopText.text = "Thank you for your purchase!";
            buttonOneText.text = "Free Willy: Sold Out.";
            optionOneBought = true;
        }
    }


    public void TooBroke()
    {
        if(!optionOneBought)
        {
            shopText.text = "You're too broke!";
        }
    }
}
