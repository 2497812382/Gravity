using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("基本信息")]
    public bool isReversed;
    public float speed;
    public float jumprate;
    public bool isOffFire = false;
    [SerializeField] private int HP = 2;
    [SerializeField] private int Key;
    [Space]
    [Header("地面检测")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [Space]
    [Header("是否反转操作")]
    [SerializeField] private bool needReverse;
    [Header("角色Ridigbody的velocity")]
    [SerializeField] private Vector2 rbVertor; // 用来看角色速度的

    private bool facingRight = true;
    private int facingDir = 1; //预留给冲刺的
    private Rigidbody2D rb;
    private new Transform transform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        var controls = new PlayerController();
        controls.KeyBoard.Enable();    
    }
    private void Update()
    {
      
        CollsionCheck();
        FlipController();
        rbVertor = rb.velocity;
        Dead();
    }
    void OnReverse(InputValue value)
    {
        if (value.isPressed)
        {
            isReversed = !isReversed; // 切换状态
            rb.gravityScale = -rb.gravityScale;

            transform.Rotate(0, 180, 180);

        }
    }

    

    void OnMove(InputValue value) //可取消的操作反转
    {
        if (needReverse)
        {
            if (!isReversed)
            {
                Vector2 movevalue = value.Get<Vector2>();
                rb.velocity = new Vector2(movevalue.x * speed, movevalue.y * jumprate);
            }
            else
            {
                Vector2 movevalue = -value.Get<Vector2>();
                rb.velocity = new Vector2(movevalue.x * speed, movevalue.y * jumprate);
            }
        }
        else
        {
            Vector2 movevalue = value.Get<Vector2>();
            if (!isReversed)
            {
                
                rb.velocity = new Vector2(movevalue.x * speed, movevalue.y * jumprate);
            }
            else
            {
                rb.velocity = new Vector2(movevalue.x * speed, -movevalue.y * jumprate);
            }
        }
    }



    public void Hurt(int damage)
    {
        this.HP -= damage;
    }

    public void Dead()
    {
        if (this.HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void GetKey()
    {
        this.Key += 1;
    }



    private void CollsionCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }


    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {
        if (rb.velocity.x > speed - Math.Pow(10, -10) && !facingRight)
            Flip();
        else if (rb.velocity.x < -speed + Math.Pow(10, -10) && facingRight)
            Flip();
    }
    public bool IsGrounded()
    {
        return isGrounded;
    }
    public bool IsReversed()
    {
        return isReversed;
    }
}
