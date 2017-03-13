using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void RestartGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    public void StartGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    public void Options() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}
