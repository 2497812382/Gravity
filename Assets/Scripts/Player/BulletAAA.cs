using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAAA : MonoBehaviour
{
    [SerializeField] private float DestoryTime = 2;


    void Start()
    {

        Destroy(gameObject, DestoryTime);//2��������ӵ�����Ȼ�ӵ������޶�
    }

    private void OnTriggerEnter2D(Collider2D collision)//�����������ײ����ʱ��
    {
        if (collision.gameObject.tag != "Enemy" 
            && collision.gameObject.tag != "CheckRange"
            && collision.gameObject.tag != "Player"
            )
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);


        }else if (collision.gameObject.tag == "Bullet")
        {
            // ���ܴ��ڱ�ը�����������ټ�
            Destroy(gameObject);
        }
    }
}
