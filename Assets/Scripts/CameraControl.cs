using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 position;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    [Header("基本参数")]
    public float camera1UpEdge;
    public float camera1DownEdge;
    

    private void Awake()
    {
       
    }
    private void Update()
    {
        position = rb.position;
        ControlCamera();
    }
    private void ControlCamera()
    {
       if(position.y<camera1DownEdge)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
        }
       if (camera1UpEdge>position.y&&position.y>camera1DownEdge)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
        }
       if(position.y>camera1UpEdge)
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
        }

    }
}
