using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Voice : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Awake()
    {
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ((int)(slider.value * 100)).ToString();
    }
}
