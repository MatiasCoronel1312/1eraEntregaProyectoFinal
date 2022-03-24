using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class DoorsEvent : MonoBehaviour
{
    public GameObject Puertas;
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<EventManager>().OnEvent += Play;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        PlayableDirector pd = Puertas.GetComponent<PlayableDirector>();
        pd.Play();
    }
}
