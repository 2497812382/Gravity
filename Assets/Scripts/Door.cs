using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    private bool PlayerNearby = false;
    public int KeyNumber = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // KeyNumber = 
        /*
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("F!");
        }
        */ // 判断开门
        if (Keyboard.current.fKey.wasPressedThisFrame && PlayerNearby)
        {
            if (KeyNumber == 9)
                anim.SetBool("IsOpen", true);
            else
                anim.SetBool("IsCantOpen", true);
        }
        
    }

    // 下列三函数判断玩家是否在门处
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Player")
            PlayerNearby = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            PlayerNearby = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            PlayerNearby = false;
    }
    
    void OpentheDoorExit() // 动画末尾的事件
    {
        anim.SetBool("IsOpen", false);
    }
    void CantOpentheDoorExit() // 动画末尾的事件
    {
        anim.SetBool("IsCantOpen", false);
    }
}
