using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnaught_Death_Script : MonoBehaviour
{
    private int childNum;//number of children attached to dreadnaught (total number of trailers)
    private int deathCount = 0;//used to keep track of how many trailers have been destroyed

    private void Start()
    {
        childNum = gameObject.transform.childCount;
    }
    public void dreadnaughtDeath()
    {
        deathCount = 0;
        
        foreach (Transform child in transform)//check how many trailers have been destroyed
        {
            if (child.transform.Find("Mesh").gameObject.activeSelf == true)
            {
                break;
            }
            else if (child.transform.Find("Mesh").gameObject.activeSelf == false)
            {
                deathCount++;
            }
        }

        if (deathCount == childNum)
        {
            Destroy(gameObject);
        }
    }

   
}