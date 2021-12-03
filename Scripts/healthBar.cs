using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider health_monitor;
    public Gradient gradient;
    public Image color;

    public void SetHealth(int destruction){
        health_monitor.value = destruction;
        color.color = gradient.Evaluate(health_monitor.normalizedValue);
    }

    public void SetMaxHealth(int destruction){
        health_monitor.maxValue = destruction;
        health_monitor.value = destruction;
        color.color = gradient.Evaluate(1f);
    }

    /* Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
