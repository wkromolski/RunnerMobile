using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private Invulnerability _invulnerability;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject lawnMower;
    [SerializeField] private RestartController _restartController;
    [SerializeField] private ScoreUI scoreUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageTrigger"))
        {

            Damage();
            _invulnerability.SetInvulnerability();
    
            hitSound.Play();
        }
    }

    public void Damage()
    {
        _restartController.Pause();
        GetComponent<PlayerController>().enabled = false;
        scoreUI.ShowFinalScore();
    }
}
