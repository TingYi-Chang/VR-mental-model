using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Goal with : " + other.name);
        if (other.gameObject.CompareTag("Target") && ResearcherManager.WaitTarget)
        {
            Debug.Log("Goal!!!!!");
            ResearcherManager.ReadyToPowerOn = true;
        }
        
    }
}
