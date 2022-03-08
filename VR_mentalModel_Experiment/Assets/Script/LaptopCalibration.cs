using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopCalibration : MonoBehaviour
{
    public GameObject Tracker_Laptop;
    Vector3 offset = new Vector3(0f, -0.1f, -0.15f);

    void Start()
    {
        Invoke("Delay", 1f);
    }

    void Delay()
    {
        gameObject.transform.position = gameObject.transform.position + Tracker_Laptop.transform.position;
        //Quaternion laptop_Q = Quaternion.Euler(Tracker_Laptop.transform.eulerAngles.x , Tracker_Laptop.transform.eulerAngles.y, Tracker_Laptop.transform.eulerAngles.z);
        //gameObject.transform.rotation = laptop_Q;
        gameObject.transform.rotation = Tracker_Laptop.transform.rotation;
        gameObject.transform.Rotate(-90f, 180f, 0f);

    }
    void Update()
    {
        
    }
}
