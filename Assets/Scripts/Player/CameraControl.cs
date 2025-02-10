using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 position;
    public Camera upScene;
    public Camera bornScene;
    public Camera downScren;
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
            upScene.enabled = false;
            bornScene.enabled = true;
            downScren.enabled = false;
        }
       if (camera1UpEdge>position.y&&position.y>camera1DownEdge)
        {
            upScene.enabled = true;
            bornScene.enabled = false;
            downScren.enabled = false;
        }
       if(position.y>camera1UpEdge)
        {
            upScene.enabled = false;
            bornScene.enabled = false;
            downScren.enabled = true;
        }

    }
}
