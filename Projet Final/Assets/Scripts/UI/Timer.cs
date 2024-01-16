using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text textBox;

    void Start()
    {
        timeStart = Time.time;
    }   
    

    void Update()
    {
        float t = Time.time - timeStart;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("F0");

        textBox.text = minutes + ":" + seconds;

    }
}

