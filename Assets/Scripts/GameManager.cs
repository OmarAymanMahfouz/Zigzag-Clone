using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public Text Score;
    public Text HighScore;
    private int score;
   

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }
    
    private void Awake()
    {
        HighScore.text = "Best: " + GetHighScore().ToString();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    public void EndGame()
    {
        if (score > GetHighScore())
            PlayerPrefs.SetInt("HighScore", score);
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        Score.text = score.ToString();
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }
}
