using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject howToPlay;
    

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);

    }

    public void HowToPlayExit()
    {
        howToPlay.SetActive(false);

    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
