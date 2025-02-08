using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float DestoryTime = 2;


    void Start()
    {
        
        Destroy(gameObject, DestoryTime);//2秒后销毁子弹，不然子弹会无限多
    }

    private void OnTriggerEnter2D(Collider2D collision)//触碰到别的碰撞器的时候
    {
        if (collision.gameObject.tag != "CheckRange" 
            && collision.gameObject.tag != "Enemy" 
            && collision.gameObject.tag != "EnemyBody"
            && collision.gameObject.tag != "Bullet")
        {

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")//如果碰撞对象是玩家
        {

            //调用player的受伤函数
            Destroy(gameObject);
            
        }
    }
}
