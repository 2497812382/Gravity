using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeadScene : MonoBehaviour
{
    private int Levelnumber;
    // Start is called before the first frame update
    void Start()
    {
        Levelnumber = PlayerPrefs.GetInt("LevelNumber");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(Levelnumber);
        }
    }
}
