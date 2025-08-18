using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public AudioSource engineVoice;
    public AudioSource tireVoice;

    public bool endGame = false ;

    public void Setup()
    {

        gameObject.SetActive(true);

        Time.timeScale = 0f;

        engineVoice.Stop();
        tireVoice.Stop();

        endGame = true;

    }

    public void restartButton()
    {

        Time.timeScale = 1f;

        endGame = false;

        SceneManager.LoadScene("SampleScene");

    }

    public void quitButton()
    {

        Application.Quit();

    }
}
