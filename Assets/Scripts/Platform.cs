using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("aaaBullet"))
        {
            other.gameObject.SetActive(false);
            // Debug.Log("Icy!");
            anim.SetBool("IsIcy",true);
        }
    }
    
    void IcyExit()
    {
        anim.SetBool("IsIcy", false);
    }
}
