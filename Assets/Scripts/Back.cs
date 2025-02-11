using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public Pause pause;
    // Start is called before the first frame update
    public void click()
    {
        pause.EnterPause();
    }
}
