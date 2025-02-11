using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 position;
    private Camera upScene;
    private Camera bornScene;
    private Camera downScren;
    private GameObject Map;
    [Header("基本参数")]
    public float camera1UpEdge;
    public float camera1DownEdge;

    

    private void Awake()
    {
        Map = GameObject.Find("Map");
        upScene = Map.transform.Find("Main Camera (1)").GetComponent<Camera>();
        bornScene = Map.transform.Find("Main Camera").GetComponent<Camera>();
        downScren = Map.transform.Find("Main Camera (2)").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
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
            bornScene.enabled = false;
            downScren.enabled = true;
        }
       if (camera1UpEdge>position.y&&position.y>camera1DownEdge)
        {
            upScene.enabled = false;
            bornScene.enabled = true;
            downScren.enabled = false;
        }
       if(position.y>camera1UpEdge)
        {
            upScene.enabled = true;
            bornScene.enabled = false;
            downScren.enabled = false;
        }

    }
}
