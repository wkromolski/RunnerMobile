using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private DamageController _damageController;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private RestartController _restartController;
    

    public void AddBonus()
    {
            _playerScore.score += 1;
    }
}
