using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                
                Resume();

            } else {

                Pause();

            }
        }
    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //completely freeze
        gameIsPaused = false;

    }

    void Pause() {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //completely freeze
        gameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main menu");

    }

    public void QuitMenu() {
        
        Application.Quit();

    }


}
