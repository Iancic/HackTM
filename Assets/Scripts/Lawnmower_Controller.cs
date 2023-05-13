using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lawnmower_Controller : MonoBehaviour
{
    private float for_Speed = 0.03f; //0.02f
    private float rot_Speed = 200f; // 200f

    private int money;

    public TMP_Text money_text;

    private float current_time, show_time;
    private float starting_time = 60f;
    public TMP_Text timer;

    public TMP_Text percentage_text;
    public GameObject[] grass_list;
    public int total, initial, percentage, how_much_grass;

    void Start()
    {
        current_time = starting_time;

        //percentage
        grass_list = GameObject.FindGameObjectsWithTag("Grass");
        initial = grass_list.Length;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            RotateObject(horizontalInput);
        }
        MoveForward();


        //Counter
        current_time -= 1 * Time.deltaTime;
        show_time = Mathf.Round(current_time);
        timer.SetText(show_time.ToString() + " left");

        if (current_time <= 0)
        {
            current_time = 0;
        }


        //percentage
        percentage = (how_much_grass * 100) / initial;
        percentage_text.SetText(percentage.ToString() + "%");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            Destroy(collision.gameObject);
            money += 1;
            money_text.SetText("$" + money.ToString());
            how_much_grass += 1;
        }
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
            money -= 50;
            money_text.SetText("$" + money.ToString());
        }
    }

        private void MoveForward()
    {
        Vector3 movement = transform.forward * for_Speed;
        transform.position += movement;
    }

    private void RotateObject(float horizontalInput)
    {
        float rotationAmount = horizontalInput * rot_Speed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
