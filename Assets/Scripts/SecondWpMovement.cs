using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWpMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed = 2f;
    [SerializeField] float rotationSpeed = 2f;
    public Transform[] waypoints;
    private int currentIndex = 0;
    [SerializeField] float minimumDistance;
    private bool goBack = false;
    [SerializeField] private Animator Zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
