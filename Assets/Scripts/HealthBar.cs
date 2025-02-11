using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    public int temphealth = 2, maxhealth = 2;
    private GameObject playerObj;
    private Player player;
    private int playerHP;
    public GameObject heart1;
    public GameObject heart2;
    private Animator anim1;
    private Image ima1;
    private Animator anim2;
    private Image ima2;
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
        health = maxhealth;
        anim1 = heart1.GetComponent<Animator>();
        ima1 = heart1.GetComponent<Image>();
        anim2 = heart2.GetComponent<Animator>();
        ima2 = heart2.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int Lasthealth = health;
        temphealth = player.HP;
        health = temphealth;
        // 第一个心
        if (health >= 1)
        {
            ima1.enabled = true;
            anim1.SetBool("IsFlash", false);
        }
        else
        {
            if(Lasthealth >= 1)
            {
                anim1.SetBool("IsFlash", true);
            }
        }
        // 第二个心
        if (health >= 2)
        {
            ima2.enabled = true;
            anim2.SetBool("IsFlash", false);
        }
        else
        {
            if (Lasthealth >= 2)
            {
                anim2.SetBool("IsFlash", true);
            }
        }
        if (health == 0)
        {
            SceneManager.LoadScene(4);
            PlayerPrefs.SetInt("LevelNumber", SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
