using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float DestoryTime = 2;


    void Start()
    {
        
        Destroy(gameObject, DestoryTime);//2��������ӵ�����Ȼ�ӵ������޶�
    }

    private void OnTriggerEnter2D(Collider2D collision)//�����������ײ����ʱ��
    {
        if (collision.gameObject.tag != "CheckRange" 
            && collision.gameObject.tag != "Enemy" 
            && collision.gameObject.tag != "EnemyBody"
            && collision.gameObject.tag != "Bullet")
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")//�����ײ���������
        {

            //����player�����˺���
            Destroy(gameObject);
            
        }
    }
}
