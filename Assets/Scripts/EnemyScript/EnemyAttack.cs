using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    
    public GameObject bulletPrefab;
    private float nextFire = 0.0F;
    private Transform player;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] public float fireRate = 0.5F;//0.5��ʵ����һ���ӵ�
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private bool isAttacking = false;
    private Animator anim;
    
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        anim = GameObject.Find("EnemyAnimator").GetComponent<Animator>();

    }

    private void Update()
    {
        if (isAttacking)
        {
            anim.SetBool("isAttacking", true);
        }else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FacePlayer();
            Shoot(fireRate, bulletSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }

    private void FacePlayer()
    {
        isAttacking = true;
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gameObject.transform.parent.rotation = Quaternion.Slerp(
        transform.rotation,
        targetRotation,
        rotationSpeed * Time.deltaTime
    );
    }


    public void Shoot(float fireRate, float bulletSpeed)
    {
        if (Time.time > nextFire)//���ӵ������м��
        {
            isAttacking = true ;
            nextFire = Time.time + fireRate;//Time.time��ʾ����Ϸ���������ڵ�ʱ�䣬��������Ϸ����ͣ��ֹͣ���㡣
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }
        
    }
}