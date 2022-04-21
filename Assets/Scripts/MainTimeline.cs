using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainTimeline : MonoBehaviour
{
    public GameObject zombie;
    

    public void Play()
    {
        PlayableDirector pd = zombie.GetComponent<PlayableDirector>();
        pd.Play();
    }
}
