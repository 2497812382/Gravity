using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O : MonoBehaviour
{
    private bool PlayerNearby;
    private SpriteRenderer sr;
    public bool GravityZoneNearby = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // GravityZoneNearby=
        // Debug.Log(PlayerNearby);
        if (GravityZoneNearby)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
