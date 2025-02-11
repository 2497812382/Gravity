using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject Menu1;
    public GameObject Menu2;
    private bool Isopen = false;
    // Start is called before the first frame update
    public void EnterPause()
    {
        if (!Isopen)
        {
            PauseUI.SetActive(true);
            Menu1.SetActive(true);
            Menu2.SetActive(false);
            Isopen = true;
            Time.timeScale = 0;
        }
        else
        {
            PauseUI.SetActive(false);
            Isopen = false;
            Time.timeScale = 1;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) EnterPause();
    }
}
