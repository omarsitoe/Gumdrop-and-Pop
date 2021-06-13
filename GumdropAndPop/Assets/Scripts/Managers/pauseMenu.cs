using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject player;
    [SerializeField] public playerManager pm;
    [SerializeField] public GameObject deathScreen;

    void Start()
    {
        pm = player.GetComponent<playerManager>();
        deathScreen.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the escape key has been pressed
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            //if game was already paused, resume. Vice versa
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

       //if the player died, activate death screen
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
        SceneManager.LoadScene("Menu");
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
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
        deathScreen.SetActive(false);
    }
}
