using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeCamera : MonoBehaviour//para los powerUp o los ammos miren al camara
{
    
    void Start()
    {
        
    }


    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
