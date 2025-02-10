using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawn : MonoBehaviour
{

    private int leftEnemyNumber, rightEnemyNumber;
    public int leftAreaNumber = 1, rightAreaNumber = 1;
    public float checkRadius;
    public GameObject enemyPrefab;
    private GameObject leftSpawnArea, rightSpawnArea;
    private Transform Area;
    private BoxCollider2D coll;
    public int targetEnmeyNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        leftEnemyNumber = rightEnemyNumber = 0;
        leftSpawnArea = GameObject.Find("LeftSpawnArea");
        rightSpawnArea = GameObject.Find("RightSpawnArea");
    }

    // Update is called once per frame
    void Update()
    {
        if (leftEnemyNumber + rightEnemyNumber >= targetEnmeyNumber) return;
        int i = 0;
        while ((++i) <= 50)
        {
            int op = Random.Range(0, 1);
            if (leftEnemyNumber >= 2) op = 1;
            if (rightEnemyNumber >= 2) op = 0;
            if (leftEnemyNumber >= 2 && rightEnemyNumber >= 2)
            {
                Debug.Log("TooManyEnemy");
            }
            Vector3 rot;
            if (op == 0)
            {
                ++leftEnemyNumber;
                op = Random.Range(1, leftAreaNumber);
                Area = leftSpawnArea.transform.Find("Area" + op.ToString());
                rot = new Vector3(0, 0, 0);
            }
            else
            {
                ++rightEnemyNumber;
                op = Random.Range(1, rightAreaNumber);
                Area = rightSpawnArea.transform.Find("Area" + op.ToString());
                rot = new Vector3(0, 180, 0);
            }
            coll = Area.GetComponent<BoxCollider2D>();
            Vector2 center = coll.bounds.center;
            Vector2 size = coll.bounds.size;
            Vector2 randomPosition = new Vector2(
                    Random.Range(center.x - size.x / 2f,
                    center.x + size.x / 2f),
                    Random.Range(center.y - size.y / 2f,
                    center.y + size.y / 2f)
            );
            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, checkRadius);
            bool isValid = true; ;
            foreach (Collider2D other in colliders)
            {
                if (other.CompareTag("Enemy") || other.CompareTag("Platform") || other.CompareTag("Player"))
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Instantiate(enemyPrefab, randomPosition, Quaternion.Euler(rot));
                break;
            }
            if (i == 50)
            {
                Debug.Log("EnemySpawnFailed");
            }
        }
    }
}
