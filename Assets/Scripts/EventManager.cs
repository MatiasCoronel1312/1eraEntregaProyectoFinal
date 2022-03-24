using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public event Action OnEvent;

    [SerializeField] private UnityEvent OnEvents;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other) {
         if(other.gameObject.CompareTag("Player"))
         {
             OnEvent?.Invoke();
             OnEvents?.Invoke();
             Debug.Log("event");
         }
     }
     
}
