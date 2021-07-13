using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        AudioListener.pause = false;
        GameObject musicObj = GameObject.FindGameObjectWithTag("gameMusic");
        musicObj.GetComponent<AudioSource>().enabled = true;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioListener.pause = true;
        GameObject musicObj = GameObject.FindGameObjectWithTag("gameMusic");
        musicObj.GetComponent<AudioSource>().enabled = false;
    }

    public void restart()
    {
        resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject musicObj = GameObject.FindGameObjectWithTag("gameMusic");
        musicObj.GetComponent<AudioSource>().enabled = true;
    }

    public void exitGame()
    {
        resume();
        SceneManager.LoadScene("menu");
        GameObject musicObj = GameObject.FindGameObjectWithTag("gameMusic");
        musicObj.GetComponent<AudioSource>().enabled = true;
    }
}
