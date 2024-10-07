using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    
    [SerializeField] private GameObject background;
    [SerializeField] private int spawningZPos = 260;
    [SerializeField] private int lengthOfSection = 260;
  
    private float offsetX = -19.1f;
    private float offsetY = -6.5f;







    public void SpawnBackground()
    {
       

        Instantiate(background, new Vector3(offsetX, offsetY, 1 * spawningZPos), transform.rotation);
        spawningZPos += lengthOfSection;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {

            SpawnBackground();
 
        }

    }
}
