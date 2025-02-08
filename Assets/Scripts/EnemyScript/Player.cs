using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 rbv;
    public float speed;
    public float jumprate;
    protected bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        CollsionCheck();
    }
    void OnJump(InputValue value)
    {
        bool Jump = value.isPressed;
        Debug.Log("Jump");
    }

    void OnMove(InputValue value)
    {
        Vector2 movevalue = value.Get<Vector2>();
        rb.velocity = new Vector2(movevalue.x * speed, movevalue.y * jumprate);
        rbv = rb.velocity;
    }
    private void CollsionCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
