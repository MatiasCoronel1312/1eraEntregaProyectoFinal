using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeCamera : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
