using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    private float current_time, show_time;
    private float intro_time = 10f;

    public TMP_Text timer_intro;

    public GameObject lawnmower;

    public int set;

    public Image image1, image2, image3, image4;

    void Start()
    {
        current_time = intro_time;
    }

    void Update()
    {
        current_time -= 1 * Time.deltaTime;
        show_time = Mathf.Round(current_time);
        timer_intro.SetText(show_time.ToString());

        if (current_time <= 1) 
        {
            image1.enabled = false;
            image2.enabled = false;
            image3.enabled = false;
            image4.enabled = false;
            current_time = 0;
            timer_intro.SetText(" ");
            lawnmower.GetComponent<Lawnmower_Controller>().for_Speed = 0.05f;

            if (set==0) 
            {
                lawnmower.GetComponent<Lawnmower_Controller>().current_time = 120f;
                set = 1;
            }

        }
    }
}
