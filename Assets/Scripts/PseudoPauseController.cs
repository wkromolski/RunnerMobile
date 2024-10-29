using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PseudoPauseController : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;  
    [SerializeField] public TextMeshProUGUI countdownText;   

    private bool isPaused = false;

    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);  
    }

    public void StartPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;                  
            pauseCanvas.gameObject.SetActive(true); 
            StartCoroutine(PauseCountdown());       
        }
    }

    private IEnumerator PauseCountdown()
    {
        int countdown = 3;

        while (countdown >= 0)  
        {
            countdownText.text = countdown.ToString(); 
            yield return new WaitForSecondsRealtime(1f); 
            countdown--; 
        }

        ResumeGame(); 
    }

    private void ResumeGame()
    {
        pauseCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1f;                   
        isPaused = false;
    }

}