using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearcherManager : MonoBehaviour
{
    public AudioSource MyAudioSource;
    public AudioClip[] MyAudioClip = new AudioClip[7];
    bool ToCloseLaptop = false;
    public static bool ReadyToPowerCut = false;
    public static bool ReadyToPowerOn = false;
    public static bool WaitTarget = false;

    public GameObject Tracker_Laptop;
    public GameObject eyeBlock;
    public GameObject light;


    // Start is called before the first frame update
    void Start()
    {
        eyeBlock.SetActive(false);
        light.SetActive(true);
        MyAudioSource = GetComponent<AudioSource>();
        Invoke("PlayWelcoming", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Tracker_Laptop.transform.position.y <= 0.8 && ToCloseLaptop) {
            ToCloseLaptop = false;
            Invoke("PlayThrowBall", 0.5f);
        }
        else if (ReadyToPowerCut)
        {
            PlayPowerCut();
            ReadyToPowerCut = false;
            WaitTarget = true;
        }
        else if (ReadyToPowerOn)
        {
            PlayEnd();
            ReadyToPowerOn = false;
        }
    }

    void PlayWelcoming()
    {
        Debug.Log("PlayWelcoming");
        MyAudioSource.PlayOneShot(MyAudioClip[0]);
        Invoke("PlayBatteryIllustration", 26f);
    }

    void PlayBatteryIllustration()
    {
        Debug.Log("PlayBatteryIllustration");
        MyAudioSource.PlayOneShot(MyAudioClip[1]);
        Invoke("PlayCloseLaptop", 14f);
        WaitTarget = true;
    }

    void PlayCloseLaptop()
    {
        Debug.Log("PlayCloseLaptop");
        MyAudioSource.PlayOneShot(MyAudioClip[2]);
        Invoke("ReadyToCloseLaptop", 14f);
    }
    void ReadyToCloseLaptop()
    {
        ToCloseLaptop = true;
    }

    void PlayThrowBall()
    {
        Debug.Log("PlayThrowBall");
        MyAudioSource.PlayOneShot(MyAudioClip[3]);
        Invoke("ReadyToThrowBall", 10f);
    }

    void ReadyToThrowBall()
    {
        ThrowBallEvent.m_ThrowBall = true;
    }

    
    void PlayThrowAgain()
    {

        MyAudioSource.PlayOneShot(MyAudioClip[4]);

    }

    void PlayPowerCut()
    {
        Debug.Log("PlayPowerCut");
        MyAudioSource.PlayOneShot(MyAudioClip[5]);
        PowerCut();
    }

    void PlayEnd()
    {
        Debug.Log("PlayEnd");
        MyAudioSource.PlayOneShot(MyAudioClip[6]);
        PowerOn();
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