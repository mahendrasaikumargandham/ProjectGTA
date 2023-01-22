using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool continueGame = false;
    public bool startGame = false;
    public static MainMenu instance;

    public void Awake() {
        Cursor.lockState = CursorLockMode.None;
        instance = this;
    }

    public void onContinueButton() {
        continueGame = true;
        SceneManager.LoadScene("Town");
    }

    public void onStartButton() {
        startGame = true;
        SceneManager.LoadScene("Town");
    }

    public void onQuitGame() {
        Application.Quit();
    }
}
