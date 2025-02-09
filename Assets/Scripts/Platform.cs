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

    private void OnTriggerEnter2D(Collider2D other) // �жϺ� aaa ����
    {
        if (other.gameObject.CompareTag("aaaBullet"))
        {
            other.gameObject.SetActive(false);
            // Debug.Log("Icy!");
            anim.SetBool("IsIcy",true);
        }
    }
    
    void IcyExit() // ����ĩβ���¼�
    {
        anim.SetBool("IsIcy", false);
    }
}
