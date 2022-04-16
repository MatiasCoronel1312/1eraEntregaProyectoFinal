using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsMovement : MonoBehaviour
{

    
    public Transform[] waypoints;
    private int currentIndex = 0;
    [SerializeField] float minimumDistance;
    private bool goBack = false;
    [SerializeField] protected EnemyData enemy;

    [SerializeField] private Animator Zombie;     
    public Transform player;
    

    
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


        if (deltaVector.magnitude <= enemy.attackPlayer) //a la distancia minima lo ataca
        {
            Zombie.SetBool("Attack", true);//activa animacion de ataque (todavia no lastima a nadie)
            Zombie.SetBool("ModePersecution", false);
        }
        else if ((deltaVector.magnitude <= enemy.distancePlayer)&&(deltaVector.magnitude >= enemy.attackPlayer)) // El enemigo cambia a modo persecucion cuando sea moner la distancia al player pero no tanto, sino lo ataca
        {
            transform.forward = Vector3.Lerp(transform.forward, direction, enemy.rotationSpeed * Time.deltaTime);// copia su angulo del player
            transform.position += direction * enemy.speedEnemy * Time.deltaTime;// y avanza
            Zombie.SetBool("ModePersecution", true);//solo activa animacion de persecucion
            Zombie.SetBool("WalkSlow", false);
            Zombie.SetBool("Attack", false);

        }
        else// y si esta muy lejos solo camina el recorrido de waypoints
        {
            Vector3 gamaVector = waypoints[currentIndex].position - transform.position;
            Vector3 directionB = gamaVector.normalized;
            transform.forward = Vector3.Lerp(transform.forward, directionB, enemy.rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * enemy.speedEnemy * Time.deltaTime;
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
