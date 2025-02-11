using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public bool PlayerNearby = false;
    private Player player;

    public int KeyNumber = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyNumber = player.GetKeyTrue();
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
        EntertheNextLevel();
    }
    void EntertheNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void CantOpentheDoorExit() // ����ĩβ���¼�
    {
        anim.SetBool("IsCantOpen", false);
    }
}
