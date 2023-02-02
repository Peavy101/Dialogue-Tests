using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject player;

    public float xPlace;
    public float yPlace;

    BoxCollider2D myBoxCollider2D;

    void Start()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Fade>().FadeIt();
            FindObjectOfType<PlayerController>().NoMove();
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds (2.5f);
        player.transform.position = new Vector2(xPlace, yPlace);
        yield return null;
    }

}
