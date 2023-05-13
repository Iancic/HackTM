using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lawnmower_Controller : MonoBehaviour
{
    private float moveSpeed = 0.01f;
    private float multiSpeed = 0.0001f;
    private float rotSpeed = 100f;
    private float multirot = 1f;

    private int money;

    public TMP_Text money_text;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            RotateObject(horizontalInput);
        }
        MoveForward();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            Destroy(collision.gameObject);
            money += 10;
            money_text.SetText("$" + money.ToString());
        }
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
            money += 10;
            money_text.SetText("$" + money.ToString());
        }
    }

        private void MoveForward()
    {
        Vector3 movement = transform.forward * moveSpeed;
        transform.position += movement;
    }

    private void RotateObject(float horizontalInput)
    {
        float rotationAmount = horizontalInput * rotSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
