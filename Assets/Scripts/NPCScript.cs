using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCScript : MonoBehaviour
{
    CircleCollider2D myCircleCollider2D;
    GameObject childObject;

    public TextMeshProUGUI dialogueText;
    public string[] dialogue;

    bool isDialogueDisplayed;
    bool isPaused = false;

    void Start()
    {
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        childObject = transform.Find("Circle").gameObject;
    }
    private bool isInRange;

    void Update()
    {
        if(myCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            childObject.SetActive(true);
            isInRange = true;
        }
        else 
        {
            childObject.SetActive(false);
            isInRange = false;
        }
        if(isInRange && Input.GetKeyDown(KeyCode.E) && !isDialogueDisplayed && !isPaused)
        {
            isDialogueDisplayed = true;
            StartCoroutine(showDialogue());
        }
    }

    IEnumerator showDialogue()
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            FindObjectOfType<DialogueUI>().Dialogue();
            dialogueText.text = dialogue[i];
            FindObjectOfType<PlayerController>().NoMove();
            yield return new WaitForSeconds(0.1f);
            //show buttons and wait for response
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape));
            dialogueText.text = "";
            FindObjectOfType<DialogueUI>().NoDialogue();
            FindObjectOfType<PlayerController>().YesMove();
        }
        isDialogueDisplayed = false;
    }

}


