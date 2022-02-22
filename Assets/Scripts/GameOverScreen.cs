using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   
   public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
        BallMovement.IsGameOver = false;
    }

    public void playAgainSettings()
    {
        apronController.isApron = false;
        GameMode.GameScore = 0f;
        GameMode.time = 0f;
    }
}
