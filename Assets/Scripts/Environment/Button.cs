using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    private Vector3 originalScale;
    private Vector3 pressedScale;




    private void Awake()
    {
        originalScale = transform.localScale;
        pressedScale = new Vector3(originalScale.x , originalScale.y * 0.8f);
        Debug.Log(originalScale);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PressButton(); // 开始踩下动画
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetOffFire();
            gameObject.SetActive(true);
            ReleaseButton(); // 开始恢复动画
            
        }
    }


    private void PressButton()
    {


        transform.localScale = pressedScale;
        

    }

    private void ReleaseButton()
    {
;
        //while (transform.localScale != originalScale)
        //{
        //    transform.localScale = Vector3.Lerp(transform.localScale, originalScale, pressSpeed * Time.deltaTime);
        //    yield return null;
        //}
        transform.localScale = originalScale;

    }
}
