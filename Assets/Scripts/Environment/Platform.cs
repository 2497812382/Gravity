using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Transform child1, child2;
    private Animator anim1,anim2;
    private float TimeGap = 5f;
    bool Tag = false;
    float Uptime = -1f;
    void Start()
    {
        child1 = transform.Find("Animation");
        child2 = transform.Find("Animation2");
        anim1 = child1.GetComponent<Animator>();
        anim2 = child2.GetComponent<Animator>();
    }

    void Update()
    {
        if (Tag)
        {
            if( Time.time > Uptime + TimeGap)
            {
                Uptime = -1f;
                Tag = false;
                anim1.SetBool("IsIcy", false);
                anim2.SetBool("IsIcy", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // ≈–∂œ∫Õ aaa œ‡≈ˆ
    {
        if (other.gameObject.CompareTag("aaaBullet"))
        {
            other.gameObject.SetActive(false);
            // Debug.Log("Icy!");
            Uptime = Time.time; 
            Tag = true;
            anim1.SetBool("IsIcy",true);
            anim2.SetBool("IsIcy",true);
        }
    }
    
}
