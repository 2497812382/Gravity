using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O : MonoBehaviour
{
    private bool PlayerNearby;
    private SpriteRenderer sr;
    public bool GravityZoneNearby = false;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        GravityZoneNearby = player.isGravity;
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
