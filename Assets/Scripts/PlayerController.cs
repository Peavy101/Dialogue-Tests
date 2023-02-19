using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;

    private Vector2 movement;
    bool isPaused = false;

    [SerializeField] float moveSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        // Get the movement input from the player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Update the Animator parameters based on the movement input
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        
        // Move the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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

}
