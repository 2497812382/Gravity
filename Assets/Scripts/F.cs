using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    private GameObject doorObj;
    private Door doorScript;
    private bool PlayerNearby;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        doorObj = GameObject.Find("Door");
         if (doorObj != null)
        {
            //Debug.Log("A");
            doorScript = doorObj.GetComponent<Door>();
        }
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerNearby = doorScript.PlayerNearby;
        // Debug.Log(PlayerNearby);
        if (PlayerNearby )
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
