using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaterBoy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Ollie()
    {
        animator.SetTrigger("Ollie");
    }


}
