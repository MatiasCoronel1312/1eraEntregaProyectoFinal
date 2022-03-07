using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2Controller : MonoBehaviour
{
    [SerializeField] public float rango2;
    [SerializeField] public GameObject player;
    void Start()
    {
        
    }

   // este checkpoint es igual al primero, quizas el bug viene por ese lado, quizas se pisa la variable no lo se
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, rango2);
        if (hit.transform.tag == "Player"){
            Debug.Log("CheckpointLoad2");
            GameManager.instancePlayer.positionPlayer=player.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
                Gizmos.color = Color.green;
                Vector3 puntoB =transform.TransformDirection(Vector3.forward) * rango2;
                Gizmos.DrawRay(transform.position, puntoB);
    }
}
