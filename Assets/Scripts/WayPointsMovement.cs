using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsMovement : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 2f;
    public Transform[] waypoints;
    private int currentIndex = 0;
    [SerializeField] float minimumDistance;
    private bool goBack = false;

    [SerializeField] private Animator Zombie;
    public Transform player;
    //public float rotationSpeed;

    public float speedEnemy;

    public float distancePlayer;
    public float attackPlayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
       
    }


    private void Movement()
    {
        Vector3 deltaVector = player.position - transform.position;
        Vector3 direction = deltaVector.normalized;


        if (deltaVector.magnitude <= attackPlayer)
        {
            Zombie.SetBool("Attack", true);
            Zombie.SetBool("ModePersecution", false);
        }
        else if ((deltaVector.magnitude <= distancePlayer)&&(deltaVector.magnitude >= attackPlayer)) // El enemigo cambia a modo persecucion cuando sea moner la distancia al player
        {
            transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);
            transform.position += direction * speedEnemy * Time.deltaTime;
            Zombie.SetBool("ModePersecution", true);
            Zombie.SetBool("WalkSlow", false);
             Zombie.SetBool("Attack", false);

        }
        else
        {
            Vector3 gamaVector = waypoints[currentIndex].position - transform.position;
            Vector3 directionB = gamaVector.normalized;
            transform.forward = Vector3.Lerp(transform.forward, directionB, rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * speedEnemy * Time.deltaTime;
            Zombie.SetBool("WalkSlow", true);
            Zombie.SetBool("ModePersecution", false);
            if (gamaVector.magnitude <= minimumDistance)
            {
                if (currentIndex >= waypoints.Length - 1)
                {
                    goBack = true;
                }
                else if (currentIndex <= 0)
                {
                    goBack = false;
                }
                if (goBack)
                {
                    currentIndex--;
                }
                else currentIndex++;
            }
        }
    }


}
