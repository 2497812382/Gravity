using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtManager : MonoBehaviour
{

    private Player playerScript;
    private void Awake()
    {
        playerScript = this.GetComponent<Player>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            if (!playerScript.isOffFire)
            {
                playerScript.Hurt( 1 );
            }
        }
    }
}
