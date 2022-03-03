using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
    public GameObject eyeBlock;
    public GameObject light;

    void Start()
    {
        eyeBlock.SetActive(false);
        light.SetActive(true);
    }

    void Update()
    {
        
    }

    void PowerCut()
    {
        eyeBlock.SetActive(true);
        light.SetActive(false);
    }

    void PowerOn()
    {
        eyeBlock.SetActive(false);
        light.SetActive(true);
    }
}
