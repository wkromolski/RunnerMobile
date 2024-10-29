using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject distanceCount;
    [SerializeField] private GameObject counter;
    

    void Update()
    {
        counter.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerScore>().Score.ToString();
        distanceCount.GetComponent<TextMeshProUGUI>().text =
            player.GetComponent<DistanceCounter>().distance.ToString("##.") + "m";
    }
}
