using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetAnimation();
    }
    public void SetAnimation()
    {
        animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
    }
}
