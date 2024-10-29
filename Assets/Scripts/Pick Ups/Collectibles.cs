using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private GameObject collectible;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private bool isPowerUp;  

    private PlayerScore _playerScore;

    void Start()
    {
        _playerScore = FindObjectOfType<PlayerScore>();  
    }

    public void Collect()
    {
        collectible.SetActive(false);
        collectSound.Play();
        AddPoints();
    }

    private void AddPoints()
    {
        int pointsToAdd = isPowerUp ? 5 : 1;  
        _playerScore.AddScore(pointsToAdd);
    }
}
