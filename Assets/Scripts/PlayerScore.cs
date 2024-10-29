using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }

    void Start()
    {
        Score = 0;
    }

    public void AddScore(int points)
    {
        Score += points;
    }
}
