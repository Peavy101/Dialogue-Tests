using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    CircleCollider2D myCircleCollider;

    void Start()
    {
        myCircleCollider = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        if(myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Inventory>().SkateboardGet();
            Destroy(gameObject);
        }
    }
}
