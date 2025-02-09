using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX, movementY;
    public float speed = 7;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x * speed;
        movementY = movementVector.y * speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX, movementY);
        // Debug.Log($"速度: {rb.velocity}  速度大小: {rb.velocity.magnitude}");

    }
}
