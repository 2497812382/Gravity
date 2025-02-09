using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAAA : MonoBehaviour
{
    [SerializeField] private float DestoryTime = 2;


    void Start()
    {

        Destroy(gameObject, DestoryTime);//2秒后销毁子弹，不然子弹会无限多
    }

    private void OnTriggerEnter2D(Collider2D collision)//触碰到别的碰撞器的时候
    {
        if (collision.gameObject.tag != "Enemy" 
            && collision.gameObject.tag != "CheckRange"
            && collision.gameObject.tag != "Player"
            && collision.gameObject.tag != "Bullet")
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);


        }
    }
}
