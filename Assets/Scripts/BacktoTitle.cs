using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoTitle : MonoBehaviour
{
    // Start is called before the first frame update
    public void click()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
