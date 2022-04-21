using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class DoorsEvent : MonoBehaviour
{
    public GameObject Puertas;
    
    private void Awake()
    {
        FindObjectOfType<EventManager>().OnEvent += Play;// este es para activar una timeline llamada por un event
    }

    
    void Update()
    {
        
    }

    public void Play()
    {
        PlayableDirector pd = Puertas.GetComponent<PlayableDirector>();// solo es para abrir las puertas del hangar
        pd.Play();
    }
}
