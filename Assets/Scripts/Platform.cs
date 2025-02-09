using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // 判断和 aaa 相碰
    {
        if (other.gameObject.CompareTag("aaaBullet"))
        {
            other.gameObject.SetActive(false);
            // Debug.Log("Icy!");
            anim.SetBool("IsIcy",true);
        }
    }
    
    void IcyExit() // 动画末尾的事件
    {
        anim.SetBool("IsIcy", false);
    }
}
