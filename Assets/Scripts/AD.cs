using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour
{
    private GameObject doorObj;
    private Door doorScript;
    private bool PlayerNearby;
    bool FirstCome = true;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        doorObj = GameObject.Find("Cage");
        if (doorObj != null)
        {
            // Debug.Log("A");
            doorScript = doorObj.GetComponent<Door>();
        }
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerNearby = doorScript.PlayerNearby;

        if (PlayerNearby && FirstCome)
        {
            
        }
        else
        {
            FirstCome = false;
            sr.enabled = false;
        }
    }
}
