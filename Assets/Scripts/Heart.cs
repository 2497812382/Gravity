using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Animator anim;
    private Image ima;
    private bool isTiming = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        ima=GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("IsFlash") && !isTiming)
        {
            isTiming = true;
            timer = 0f;
        }
        if (!anim.GetBool("IsFlash"))
        {
            isTiming = false;
            timer = 0f;
        }
        if (isTiming)
        {
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                isTiming = false;
                timer = 0f;
                anim.SetBool("IsFlash", false);
                ima.enabled = false;
            }

        }
    }
}
