using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    void Update()
    {
        // Retry or leave
        if(Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("MainLevel");
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
