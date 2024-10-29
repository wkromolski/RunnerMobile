using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject distanceCount;
    [SerializeField] private GameObject counter;
    [SerializeField] public TextMeshProUGUI urScore;    
    [SerializeField] public TextMeshProUGUI highScoreText;  
    [SerializeField] public Canvas deathCanvas;
    [SerializeField] public Canvas gameCanvas;
    private bool isGameOver = false;

    void Start()
    {
        deathCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            counter.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerScore>().Score.ToString();
            distanceCount.GetComponent<TextMeshProUGUI>().text =
                player.GetComponent<DistanceCounter>().distance.ToString("##.") + "m";
        }
    }

    public void ShowFinalScore()
    {
        isGameOver = true;


        gameCanvas.gameObject.SetActive(false);
        deathCanvas.gameObject.SetActive(true);

       
        int finalScore = player.GetComponent<PlayerScore>().Score;
        urScore.text = "Your Score: " + finalScore.ToString();

        
        int highScore = PlayerPrefs.GetInt("HighScore", 0);  
        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);    
            PlayerPrefs.Save();
        }

        
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
