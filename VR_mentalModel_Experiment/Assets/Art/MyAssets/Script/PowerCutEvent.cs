using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCutEvent : MonoBehaviour
{
    public GameObject eyeBlock;

    void Start()
    {
        eyeBlock.SetActive(false);
    }

    void Update()
    {
        
    }

    void PowerCut()
    {
        eyeBlock.SetActive(true);

    }
}
