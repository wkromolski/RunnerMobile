using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private Invulnerability _invulnerability;
    [SerializeField] private AudioSource hitSound;

    
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
        _healthController.playerHealth = _healthController.playerHealth - damage;
        _healthController.UpdateHealth();


    }
}
