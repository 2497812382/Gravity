using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputControls inputControl;

    public Vector2 inputDirection;
    public Rigidbody2D rb;
    [Header("基本参数")]
    public float speed;
   
    public float gravityDir =1;

    private void Awake()
    {
        inputControl = new InputControls();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        inputControl.Enable();
    }
   private void OnDisable()
    {
        inputControl.Disable();
    }
    private void Update()
    {
        inputDirection = inputControl.GamePlay.Movement.ReadValue<Vector2>();
        if(rb.gravityScale>0)
            gravityDir = 1;
        else
            gravityDir = -1;
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x*Time.deltaTime * speed,rb.velocity.y);
        
        //flip
        int facDir =(int)transform.localScale.x;
        if (inputDirection.x>0)
            facDir = 1;
        else if (inputDirection.x<0)
            facDir = -1;

        transform.localScale = new Vector3(facDir, gravityDir, 1);
    }


}
   
