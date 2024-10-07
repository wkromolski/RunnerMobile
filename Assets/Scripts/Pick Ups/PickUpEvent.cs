using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PickUpEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.Invoke();
        }
    }
}
