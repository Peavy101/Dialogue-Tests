using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public Button[] responseButtons;

    CircleCollider2D myCircleCollider;

    private int dialogStep = 0;

    private void Start()
    {
        myCircleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyDown(KeyCode.E))
        {
            JoeyInteract();
        }
    }

    private void JoeyInteract()
    {
        // Initialize dialog
        FindObjectOfType<DialogueUI>().Dialogue();
        FindObjectOfType<PlayerController>().NoMove();
        dialogStep = 0;
        textBox.text = "Hey dude, how’s it going? Mind if I ask you a question?";
        responseButtons[0].gameObject.SetActive(true);
        responseButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Questions? From a stranger?";
        responseButtons[1].gameObject.SetActive(true);
        responseButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Hit me";        
    }

    public void OnResponseClicked(int responseIndex)
    {
        // Handle button click
        switch (dialogStep)
        {
            case 0:
                if (responseIndex == 0)
                {
                    textBox.text = "Whatever dude, I guess I’ll ask someone cooler..";
                    responseButtons[0].gameObject.SetActive(false);
                    responseButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Back";
                }
                else if (responseIndex == 1)
                {
                    textBox.text = "Church bro, you seem pretty cool yourself. Do you skate?";
                    responseButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = "No";
                    responseButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Oh yeah";
                    dialogStep++;
                }
                dialogStep++;
                break;
            case 1:
                if (responseIndex == 1)
                {
                    FindObjectOfType<PlayerController>().YesMove();
                    FindObjectOfType<DialogueUI>().NoDialogue();
                }
                dialogStep++;
                break;
            case 2:
                if (responseIndex == 1)
                {
                    textBox.text = "Sweet man! I knew you were a skater! Here take this rad skateboard!";
                    responseButtons[0].gameObject.SetActive(false);
                    responseButtons[1].gameObject.SetActive(true);
                    FindObjectOfType<Inventory>().PostersGet();
                    responseButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Thanks!";
                }
                else if (responseIndex == 0)
                {
                    textBox.text = "Lame dude, totally lame.";
                    responseButtons[0].gameObject.SetActive(false);
                    responseButtons[1].gameObject.SetActive(true);
                    responseButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Back";
                }
                dialogStep++;
                break;
            case 3:
                if(responseIndex == 0)
                {
                    FindObjectOfType<PlayerController>().YesMove();
                    FindObjectOfType<DialogueUI>().NoDialogue();
                }
                else if(responseIndex == 1)
                {
                    FindObjectOfType<PlayerController>().YesMove();
                    FindObjectOfType<DialogueUI>().NoDialogue();
                }
                break;
            case 4:
                break;
        }
    }
}
