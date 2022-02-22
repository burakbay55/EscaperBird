using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMode : MonoBehaviour
{
    public static float GameScore = 0f;
    public Text score;
    public Text endScore;
    public Text savedScore;
    private float lastScore;
    public GameObject scoreButton;
    public GameObject gameOverScreen;
    public static float time;

    public Animator anim;
    //public GameObject pauseButton;
    //public GameObject playButton;
    public static bool isPausedButton = false;
    
    public void pauseGame()
    {
      Time.timeScale = 0f;
      //pauseButton.SetActive(false);
      //playButton.SetActive(true);
      isPausedButton = true;
    }

    public void playGame()
    {
        Time.timeScale = 1f;
        //playButton.SetActive(false);
        //pauseButton.SetActive(true);
        
        isPausedButton = false;
    }

    public void backMenu()
    {
      GameScore = 0f;
      time = 0f;
      BallMovement.IsGameOver = false;
      SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        playGame();
        gameOverScreen.SetActive(false);
    }
    void Update()
    {
        time+=Time.deltaTime;

         if(GameScore > PlayerPrefs.GetFloat("scored"))
         {
          anim.SetTrigger("start");
         }
        
        if (BallMovement.IsGameOver == false)
        {
            score.text = ((int)GameScore).ToString();
            
        }
         else
        {
            scoreButton.SetActive(false);
            gameOverScreen.SetActive(true);
            endScore.text = ((int)GameScore).ToString();
            
            //high score kayit ve sorgulama. 
            if(PlayerPrefs.HasKey("scored") == false)
            {
              savedScore.text = ((int)GameScore).ToString();
              PlayerPrefs.SetFloat("scored",GameScore);
            }
            else if(GameScore < PlayerPrefs.GetFloat("scored"))
            {
               lastScore = PlayerPrefs.GetFloat("scored");
               savedScore.text =  ((int)lastScore).ToString();
            }
            else if(GameScore > PlayerPrefs.GetFloat("scored"))
            {
               PlayerPrefs.SetFloat("scored",GameScore);
               savedScore.text = ((int)GameScore).ToString();
            }
        }
    }
    
}
