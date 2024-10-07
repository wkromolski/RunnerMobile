using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUp", menuName = "PickUp")]
public class PickUp : ScriptableObject
{
    [SerializeField] private int pointValue;
    [SerializeField] private int healthValue;
}
