using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    private void Start() {
        // Initialize the number of breakable objects
        Brick.breakableCount = GameObject.FindGameObjectsWithTag("Breakable").Length;
    }

    public void LoadLevel(string levelName) {
        //Debug.Log("Level load requested for: " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void QuitRequest() {
        Debug.Log("Someone wants to quit the game!");
        Application.Quit();
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
