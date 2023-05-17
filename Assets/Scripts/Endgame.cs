using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Introduction");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

    }
}
