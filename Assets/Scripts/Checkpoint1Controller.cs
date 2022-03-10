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

    
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, rango);
        if (hit.transform.tag == "Player"){
            //Debug.Log("CheckpointLoad");
           // GameManager.instancePlayer.positionPlayer=player.transform.position;
            
        }
    }

    private void OnDrawGizmos()
    {
                Gizmos.color = Color.green;
                Vector3 puntoB =transform.TransformDirection(Vector3.forward) * rango;
                Gizmos.DrawRay(transform.position, puntoB);
    }
}
