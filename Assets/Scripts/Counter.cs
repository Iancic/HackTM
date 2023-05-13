using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private float current_time, show_time;
    private float intro_time = 5f;

    public TMP_Text timer_intro;

    void Start()
    {
        current_time = intro_time;
        //Time.timeScale = 0f;
    }

    void Update()
    {
        current_time -= 1 * Time.deltaTime;
        show_time = Mathf.Round(current_time);
        timer_intro.SetText(show_time.ToString());

        if (current_time <= 1) 
        {
            current_time = 0;
            timer_intro.SetText(" ");
        }
    }
}
