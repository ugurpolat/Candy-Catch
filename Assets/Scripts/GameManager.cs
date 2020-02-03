using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    

    int score = 0;
    bool gameOver = false;
    public Text scoreText;
    int lives = 3;

    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
        
    }
    public void DecreaseLife()
    {
        
        if (lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        if (lives <= 0)
        {
            gameOver = true;

            GameOver();

        }
    }

    public void GameOver()
    {
        
        CandySpawner.instance.StopSpawingCandies();
        //GameObject.Find("CandySpawner").GetComponent<CandySpawner>().StopSpawingCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        //PlayerController.instance.canMove = false;
        gameOverPanel.SetActive(true);
        print("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

    }

    public void BackToMenu()
    {

        SceneManager.LoadScene("Menu");
    }
}
