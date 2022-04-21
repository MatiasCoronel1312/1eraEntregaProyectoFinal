using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager : MonoBehaviour// script que activa por trigger el event de apagar el grito de zombis, abrir las puertas del hangar encender otra musica y generar muchos enemigos
{
    public event Action OnEvent;

    [SerializeField] private bool isEvent = false;

    [SerializeField] private UnityEvent OnEvents;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")&&(!isEvent))
        {
            isEvent=true;
            OnEvent?.Invoke();// uso los eventos de C# y los de unity
            OnEvents?.Invoke();
            Debug.Log("event");
        }
    }

}
