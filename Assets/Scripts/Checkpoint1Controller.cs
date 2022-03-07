using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1Controller : MonoBehaviour
{
    [SerializeField] public float rango;
    [SerializeField] public GameObject player;
    void Start()
    {
        
    }

    //Checkpoint con raycast, este es sencillo porque no necesita rotar, solo esta fijo y si hace contacto con el player manda la position al GameManager
    //me gustaria saber si de esta forma consume muchos recursos o esta bien? porque al ser varios checkpoint y al estar en el update capaz no es lo mas eficiente
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, rango);
        if (hit.transform.tag == "Player"){
            Debug.Log("CheckpointLoad");
            GameManager.instancePlayer.positionPlayer=player.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
                Gizmos.color = Color.green;
                Vector3 puntoB =transform.TransformDirection(Vector3.forward) * rango;
                Gizmos.DrawRay(transform.position, puntoB);
    }
}
