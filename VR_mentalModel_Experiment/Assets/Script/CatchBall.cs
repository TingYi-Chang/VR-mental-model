using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBall : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Ball_other;
    public GameObject Ball_inBasket;
    bool HasBallinHand = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger : " + other.name);
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            Ball_other.SetActive(false);
            Ball.SetActive(true);
            HasBallinHand = true;
            ThrowBallEvent.m_catchBall = true;
        }
        else if (other.gameObject.CompareTag("Basket") && HasBallinHand)
        {
            Ball.SetActive(false);
            Ball_inBasket.SetActive(true);
            ResearcherManager.ReadyToPowerCut = true;
            HasBallinHand = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Ball_other.SetActive(false);
        Ball.SetActive(false);
    }

}
