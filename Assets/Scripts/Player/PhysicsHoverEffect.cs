using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHoverEffect : MonoBehaviour
{
    public float hoverHeight = 5f;  //计划悬浮高度
    public float hoverForce = 0.3f;  //悬浮力
    //public float hoverDistance;
    public Vector2 rayDir ;
    public LayerMask hoverLayer;
    public RaycastHit2D hit;

    public Rigidbody2D rb;
    public PlayerController player;
    private void Awake ()
    {
        player = GetComponent<PlayerController>();  
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update ()
    {

        if (player.gravityDir > 0)
            rayDir = Vector2.down;
        else rayDir = Vector2.up;
    }
    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position,rayDir,hoverHeight,hoverLayer);
        //if hit target layer
        if(hit.collider != null)
        {
            float force = hit.distance-hoverHeight;
            rb.AddForce(rayDir * force, ForceMode2D.Force);
        }
    }


}
