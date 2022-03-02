using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
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
