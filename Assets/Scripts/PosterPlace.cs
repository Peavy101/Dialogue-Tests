using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterPlace : MonoBehaviour
{
    BoxCollider2D myBoxCollider;
    public GameObject inventory;
    public Sprite boardWPoster;
    bool canPlacePoster = false;

    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.GetComponent<Inventory>().hasPosters)
        {
            canPlacePoster = true;
        }
        if(myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyDown(KeyCode.E) && canPlacePoster)
        {
            GetComponent<SpriteRenderer>().sprite = boardWPoster;
        }
    }
}
