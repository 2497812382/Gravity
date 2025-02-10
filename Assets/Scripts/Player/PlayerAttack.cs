using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    [SerializeField] private GameObject aaaPrefab;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    private float nextFire = 0.0F;
    [SerializeField] private bool isGrounded;

    private Player script;
    private Transform playerTransform;



    private void Start()
    {
        script = transform.parent.GetComponent<Player>();

        playerTransform = transform.parent;
    }

   

    private void Update()
    {
        isGrounded = script.IsGrounded();



        if (!isGrounded)
        {
            
            WaaoFall(bulletSpeed, fireRate, minAngle, maxAngle);
        }
    }





    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LookAtEnemy(collision);
            Waao(bulletSpeed, fireRate);
        }
    }

    private void LookAtEnemy(Collider2D collision)
    {
        Vector2 direction = collision.gameObject.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }



    public void Waao(float bulletSpeed, float fireRate)
    {
        if (Time.time > nextFire)//���ӵ������м��
        {
            nextFire = Time.time + fireRate;//Time.time��ʾ����Ϸ���������ڵ�ʱ�䣬��������Ϸ����ͣ��ֹͣ���㡣
            GameObject bullet = Instantiate(aaaPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }
    }

    private void WaaoFall(float bulletSpeed, float fireRate, float minAngle, float maxAngle)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            float randomAngle = Random.Range(minAngle, maxAngle);
            // ������Ƕ�ת��Ϊ��������
            Vector2 direction = Quaternion.Euler(0f, 0f, randomAngle) * playerTransform.up;
            // ʵ�����ӵ������ó�ʼλ�úͷ���
            GameObject bullet = Instantiate(aaaPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
