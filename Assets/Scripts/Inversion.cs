using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inversion : MonoBehaviour
{
    
    public InputControls inverseAction;
    public bool isInversion;        //是否启用翻转指示物
    public PhysicsHoverEffect hoverEffect;
    public Rigidbody2D rb;
    private void Awake()
    {
        inverseAction = new InputControls();

        inverseAction.GamePlay.Inversion.started += InversionControl;

        hoverEffect = GetComponent<PhysicsHoverEffect>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inverseAction.Enable();
    }
    private void OnDisable()
    {
        inverseAction.Disable(); 
    }
    private void Update()
    {
            InversionAct();
    }
    private void InversionControl(InputAction.CallbackContext context)
    {
        //Debug.Log("inversion");
        if (hoverEffect.hit.collider != null)
        {
                isInversion = true;
                
                // Debug.Log("true");           
        }     
    }
    public void InversionAct()
    {
        if (isInversion)
        {
            
          
            isInversion=false;
            ////人物图像翻转\重力翻转
            rb.gravityScale=-rb.gravityScale;   
            
        }

    }
}
