using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{

    public GameOverManager gameOverManager;

    public Car car;

    public void Setup()
    {

        if (!gameOverManager.endGame)
        {

            gameObject.SetActive(true);

        }

    }

    public void quitGame()
    {

        Application.Quit();

    }

    public void unPauseButton()
    {

        gameObject.SetActive(false);

        car.ResumeGame();

    }

}
