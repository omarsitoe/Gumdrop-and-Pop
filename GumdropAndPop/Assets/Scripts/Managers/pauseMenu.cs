using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject player;
    [SerializeField] public playerManager pm;
    [SerializeField] public GameObject deathScreen;
    [SerializeField] public Text showTime;

    public float timer, maxTime = 30.0f;

    void Start()
    {
        pm = player.GetComponentInChildren<playerManager>();
        deathScreen.SetActive(false);
        pauseMenuUI.SetActive(false);

        // Set timer
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Update and show timer
        timer -= Time.deltaTime;
        if(timer > 0.0f) {
            showTime.text = "Time Left:  " + Mathf.RoundToInt(timer) + "  !!!";
        }
        else {
            showTime.text = "Time Ran Out!!!";
            pm.Kill();
        }
            


        // Checks if the escape key has been pressed
       if(Input.GetKeyDown(KeyCode.Escape)) {
            //if game was already paused, resume. Vice versa
            if(GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }

       // If the player died, activate death screen

       if(pm.isDead)
        {
            deathScreen.SetActive(true);
        }
    }

    //resumes the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //pauses the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //brings us to the menu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //quits the game
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    //reloads the scene
    public void Retry()
    {
        SceneManager.LoadScene("MainLevel");
        Time.timeScale = 1f;
        deathScreen.SetActive(false);
    }
}
