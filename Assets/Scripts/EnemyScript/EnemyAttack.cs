using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    
    public GameObject bulletPrefab;
    private float nextFire = 0.0F;
    private Transform player;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] public float fireRate = 0.5F;//0.5秒实例化一个子弹
    [SerializeField] private float bulletSpeed = 10f;
    
    private void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gameObject.transform.parent.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
            Shoot(fireRate, bulletSpeed);
        }
    }



    public void Shoot(float fireRate, float bulletSpeed)
    {
        if (Time.time > nextFire)//让子弹发射有间隔
        {
            nextFire = Time.time + fireRate;//Time.time表示从游戏开发到现在的时间，会随着游戏的暂停而停止计算。
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }
    }
}