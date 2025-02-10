using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("基础信息")]
    public bool isReversed;
    public float speed;
    public float jumprate;
    public bool isOffFire = false;
    public bool isInvincible = false;
    [SerializeField] private int HP = 2;
    [SerializeField] private int Key;
    [SerializeField] private float invincibilityTime;
    [SerializeField] private float offFireTime = 2f;
    [Header("受伤跳起来的力度")]
    [SerializeField] private float jumpForce;
    [Space]
    [Header("地面检测")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [Space]
    [Header("是否反转操作")]
    [SerializeField] private bool needReverse;
    [Header("显示Ridigbody的velocity")]
    [SerializeField] private Vector2 rbVertor; 

    private bool facingRight = true;
    private int facingDir = 1; 
    private Rigidbody2D rb;
    private new Transform transform;
    [SerializeField] private SpriteRenderer render;
    private Color hurtColor = new Color(255, 91, 81, 255); // 受伤时的颜色（红色）
    private Color originalColor; // 玩家原始颜色
    private float flashDuration = 0.3f; // 闪烁周期
    private float offFireTimer;

    private void Awake()
    {
        //render = transform.Find("PlayerAnimation").GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        var controls = new PlayerController();
        controls.KeyBoard.Enable();
        originalColor = render.material.color; // 保存原始颜色
    }
    private void Update()
    {
        CollsionCheck();
        FlipController();
        rbVertor = rb.velocity;
        CountTimeForFireOff();

    }

    private void CountTimeForFireOff()
    {
        if (isOffFire)
        {
            offFireTimer += Time.deltaTime;

            if (offFireTimer >= offFireTime)
            {
                isOffFire = false;
                offFireTimer = 0f;
            }
        }
    }

    void OnReverse(InputValue value)
    {
        if (value.isPressed)
        {
            isReversed = !isReversed; // �л�״̬
            rb.gravityScale = -rb.gravityScale;

            transform.Rotate(0, 180, 180);

        }
    }

    void OnJump(InputValue value)
    {
        Vector2 movevalue = value.Get<Vector2>();
        if (isGrounded) { 
            if (!isReversed)
            {
                rb.velocity = new Vector2(rb.velocity.x, movevalue.y * jumprate);
            }else
            {
                rb.velocity = new Vector2(rb.velocity.x, -movevalue.y * jumprate);
            }
        }

    }

    void OnMove(InputValue value)  
    {
        Vector2 movevalue = value.Get<Vector2>();
        if (needReverse)
        {
            if (!isReversed)
            {
                
                rb.velocity = new Vector2(movevalue.x * speed, rb.velocity.y);
            }
            else
            {
                
                rb.velocity = new Vector2(-movevalue.x * speed, rb.velocity.y);
            }
        }
        else
        {
 
                rb.velocity = new Vector2(movevalue.x * speed, rb.velocity.y);
           
        }
    }



    public void Hurt(int damage)
    {
        if (isInvincible) return; // 如果处于无敌状态，不受到伤害

        HP -= damage; // 减少血量
        if (HP <= 0)
        {
            Die(); 
        }

        // 受伤时的反馈效果
        StartCoroutine(HurtEffects());
    }


    private IEnumerator HurtEffects()
    {
        // 1. 上跳
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // 2. 变红
        render.material.color = hurtColor;
        yield return new WaitForSeconds(0.2f); // 变红持续 0.2 秒
        render.material.color = originalColor; // 恢复原色

        // 3. 无敌闪烁
        isInvincible = true;
        float timer = 0.0f;
        while (timer < invincibilityTime)
        {
            timer += Time.deltaTime;
            float remainder = timer % flashDuration;
            render.enabled = remainder > flashDuration / 2;

            yield return null;
        }

        // 无敌状态结束
        isInvincible = false;
        render.enabled = true;
    }


    public void SetOffInvincibility()
    {
        isInvincible = true;

    }

    public void SetOffFire()
    {

        isOffFire = true;
        offFireTimer = 0f;
    }


    public void Die()
    {
        Destroy(this.gameObject);
 
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
