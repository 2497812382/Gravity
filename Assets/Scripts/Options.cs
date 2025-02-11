using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject Menu1;
    public GameObject Menu2;
    // Start is called before the first frame update
    public void EnterOptions()
    {
        PauseUI.SetActive(true);
        Menu1.SetActive(false);
        Menu2.SetActive(true);
    }
}
