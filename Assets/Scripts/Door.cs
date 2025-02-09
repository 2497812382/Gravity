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
        */ // �жϿ���
        if (Keyboard.current.fKey.wasPressedThisFrame && PlayerNearby)
        {
            if (KeyNumber == 9)
                anim.SetBool("IsOpen", true);
            else
                anim.SetBool("IsCantOpen", true);
        }
        
    }

    // �����������ж�����Ƿ����Ŵ�
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
    
    void OpentheDoorExit() // ����ĩβ���¼�
    {
        anim.SetBool("IsOpen", false);
    }
    void CantOpentheDoorExit() // ����ĩβ���¼�
    {
        anim.SetBool("IsCantOpen", false);
    }
}
