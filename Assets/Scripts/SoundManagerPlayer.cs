using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour 
{
    // el control de audios y efectos, tambien controla el volumen de cada efecto
    [SerializeField] private AudioClip [] audios;
    private AudioSource controlAudio;

     private void Awake() {
         
         controlAudio = GetComponent<AudioSource>();
        
    }
    public void SeleccionAudio (int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice],volumen);
    }
}
