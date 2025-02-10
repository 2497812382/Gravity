using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public Pause pau;
    // Start is called before the first frame update
    public void Click()
    {
        pau.EnterPause();
    }
}
