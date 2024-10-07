using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectsVisibleRandomly : MonoBehaviour
{

    [SerializeField] private GameObject[] objectsToToggle;
    [SerializeField] private float visibilityRatio = 0.55f;

    private void Awake()
    {
      
        

    }


    public void RandomSet()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(Random.value > visibilityRatio);
        }
    }
}
