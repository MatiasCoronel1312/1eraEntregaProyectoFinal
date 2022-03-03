using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWpMovement : MonoBehaviour
{
     //este es el segundo enemigo, es igual que el primero pero solo sigue los waypoints
    //la idea es que sean iguales pero se instancien en diferentes lugares
   
    [SerializeField] float Speed = 2f;
    [SerializeField] float rotationSpeed = 2f;
    public Transform[] waypoints;
    private int currentIndex = 0;
    [SerializeField] float minimumDistance;
    private bool goBack = false;
    [SerializeField] private Animator Zombie;

    void Start()
    {
        
    }

   
    void Update()
    {
        Movement();
    }
    private void Movement(){
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * Speed * Time.deltaTime;
        Zombie.SetBool("WalkSlow",true);
        if(deltaVector.magnitude<=minimumDistance){
            if(currentIndex >= waypoints.Length - 1){
                goBack = true;
            }
            else if(currentIndex <= 0){
                goBack = false;
            }
            if(goBack){
                currentIndex --;
            }
            else currentIndex++;
    }
    }
}
