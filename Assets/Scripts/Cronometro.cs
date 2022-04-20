using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text UItexto;
    private int contador= 60;
    private SoundManagerPlayer soundManager;

    private void Awake() {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
        InvokeRepeating("Timer",0f,1f);
    }

    private void Timer()
    {
        contador--;
        if(contador<=0)
        {
            this.enabled=false;
        }
        soundManager.SeleccionAudio(7, 0.1f);
        UItexto.text = contador.ToString();
        
    }
}
