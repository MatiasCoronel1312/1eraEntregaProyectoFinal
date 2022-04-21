using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour//es un timer para retrasar un poquito el inicio del nivel y le de tiempo al timeline 
{
    public float Timer = 0f;
    public bool play = false;

    public float inicio= 3f;

    public void NextLevel()
    {
        play = true;
        
    }

    private void Update()
    {
        if (play == true)
        {
            Timer += Time.deltaTime;
        }
        IniciarNivel();

    }
    public void IniciarNivel()
    {
        
        if (Timer > inicio)
        {
            SceneManager.LoadScene("Nivel1");
        }
        
    }

}
