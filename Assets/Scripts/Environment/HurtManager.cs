using System.Collections;
using System.Collections.Generic;
using UnityEditor.UnityLinker;
using UnityEngine;

public class HurtManager : MonoBehaviour
{

    private Player playerScript;
    private float damageTimer = 0f; // 定时器





    private void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }


    private void Update()
    {
        damageTimer += Time.deltaTime;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (playerScript.isInvincible) return;
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Fire")
            {

                if (damageTimer >= 1f && !playerScript.isOffFire)
                {
                    playerScript.Hurt(1);
                    damageTimer = 0f; // 重置定时器

                }

            }
            else if (gameObject.tag == "Bullet")
            {
                playerScript.Hurt(1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        damageTimer = 0f; // 重置定时器
    }
}
