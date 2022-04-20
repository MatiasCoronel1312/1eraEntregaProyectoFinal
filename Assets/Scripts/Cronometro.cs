using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text UItexto;
    private int contador= 60;

    private void Awake() {
        InvokeRepeating("Timer",0f,1f);
    }

    private void Timer()
    {
        contador--;
        UItexto.text = contador.ToString();
    }
}
