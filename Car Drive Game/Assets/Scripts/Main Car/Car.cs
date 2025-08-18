using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public GameOverManager gameOverManager;

    public GamePauseManager gamePauseManager;

    public Transform mainCar;

    public AudioSource engineVoice;
    public AudioSource tireVoice;

    private bool isPaused = false;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Car"))
        {

            gameOver();

        }

    }
    public void gameOver()
    {

        gameOverManager.Setup();

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {

        if (!gameOverManager.endGame)
        {

            Time.timeScale = 0f;

            isPaused = true;

            engineVoice.Pause();
            tireVoice.Pause();

            gamePauseManager.Setup();

        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 

        isPaused = false;

        engineVoice.UnPause();
        tireVoice.UnPause();

        gamePauseManager.gameObject.SetActive(false); 
}
}
