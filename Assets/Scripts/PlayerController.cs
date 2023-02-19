using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;

    public GameObject inventory;
    public GameObject skateboardImage;

    private Vector2 movement;
    bool isPaused = false;
    bool isSkateboarding = false;

    [SerializeField] float moveSpeed = 4f;

    void Start()
    {
        skateboardImage.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        skateboardManager();
        // Get the movement input from the player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Update the Animator parameters based on the movement input
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnPause()
    {
        if(!isPaused)
        {
            Time.timeScale = 0;
            FindObjectOfType<Inventory>().Pause();
            isPaused = true;
        }
        else if(isPaused)
        {
            Time.timeScale = 1;
            FindObjectOfType<Inventory>().UnPause();
            isPaused = false;
        }
    }

    public void NoMove()
    {
        moveSpeed = 0;
    }
    public void YesMove()
    {
        moveSpeed = 4f;
    }

    void skateboardManager()
    {
        if(Input.GetKeyDown(KeyCode.X) && inventory.GetComponent<Inventory>().hasSkateboard && !isSkateboarding)
        {
            Debug.Log("Woohoo you're skateboarding!");
            skateboardImage.gameObject.SetActive(true);
            isSkateboarding = true;
            moveSpeed = 8f;
        }
        else if(Input.GetKeyDown(KeyCode.X) && inventory.GetComponent<Inventory>().hasSkateboard && isSkateboarding)
        {
            skateboardImage.SetActive(false);
            isSkateboarding = false;
            moveSpeed = 4f;
        }
    }
}
