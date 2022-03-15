using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EscapeDoorController : MonoBehaviour
{
    public PlayableDirector timeline;

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }


    void Update()
    {
        // timeline.Stop();
        // timeline.Play();
    }
}
