using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth = 3;
    [SerializeField] private Image[] hearts;

    [SerializeField] private DamageController _damageController;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private RestartController _restartController;


    private void Start()
    {
        
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (playerHealth <= 0) 
        {

            _restartController.Pause();
            GetComponent<PlayerController>().enabled = false;

        }


        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < playerHealth)
                {
                    hearts[i].color = Color.red;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
            }
        }
    }

    public void AddHealth()
    {
        if (playerHealth < 3)
        {
            playerHealth += 1;
            UpdateHealth();
        }
        else
        {
            _playerScore.score += 5;
        }
    }
}
