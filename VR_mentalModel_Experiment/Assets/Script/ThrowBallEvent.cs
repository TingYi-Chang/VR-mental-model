using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallEvent : MonoBehaviour
{
    Animator m_Animator;
    public static bool m_ThrowBall = false;
    public static bool m_catchBall = false;
    public GameObject Ball_prefab;
    public GameObject Ball_reBorn;
    GameObject theBall;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ThrowBall)
        {
            m_Animator.SetBool("ThrowBall", true);
            Debug.Log("Throw !");
            InvokeRepeating("ThrowMyBall", 0.8f, 1.95f);
            m_ThrowBall = false;
        }
        else if (m_catchBall)
        {
            m_Animator.SetBool("ThrowBall", false);
            CancelInvoke();
        }

    }

    void ThrowMyBall()
    {
        theBall = Instantiate(Ball_prefab, Ball_reBorn.transform.position, Quaternion.identity);
        theBall.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 2.9f + Vector3.up * 1.5f);
        Destroy(theBall, 4f);
    }
}
