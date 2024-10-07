using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float startingPos;
    private float currentPos;
    public float distance;
    
    void Start()
    {
        startingPos = player.transform.position.z;
    }

    
    void Update()
    {
        currentPos = player.transform.position.z;
        distance = currentPos - startingPos;
    }
}
