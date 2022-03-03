using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    public GameObject Tracker_Origin;
    Vector3 offset = new Vector3(0f, -0.73f, 0f);

    void Start()
    {
        gameObject.transform.position = Tracker_Origin.transform.position + offset;
        //gameObject.transform.rotation = Tracker_Origin.transform.rotation;
    }
}
