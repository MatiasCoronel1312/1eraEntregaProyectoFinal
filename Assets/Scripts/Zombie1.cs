using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : MonoBehaviour
{

    private new Rigidbody rigidbody;
    //[SerializeField] public GameObject [] waypoints;
    //private int currentIndex = 0;
    //[SerializeField] float minimumDistance;
    //private bool goBack = false;
    [SerializeField] protected EnemyData enemy;
    [SerializeField] private Animator Zombie;     
    [SerializeField] private GameObject player;
    [SerializeField] Collider colliderAttack; 
    [SerializeField] Collider colliderBite; 
    [SerializeField] public EnemyCollision zombieMove;

    

    
    private void Awake()
    {
    player = GameObject.Find("Player");
    rigidbody = GetComponent<Rigidbody>();
    //waypoints = GameObject.FindGameObjectsWithTag("Waypoins");

    
    
    }

    
    void Update()
    {
        Movement();
        //IsGrounded();

        if(zombieMove.isDeath){
            this.enabled=false;
        }
        
    }


    private void Movement()
    {
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 direction = deltaVector.normalized;

        if (deltaVector.magnitude <= enemy.bitePlayer) 
        {
            Zombie.SetBool("NeckBite", true);
            Zombie.SetBool("Attack", false);//activa animacion de ataque 
            Zombie.SetBool("Persecution", false);
            colliderBite.enabled=true;
            colliderAttack.enabled=false;
        }
        else if ((deltaVector.magnitude <= enemy.attackPlayer)&&(deltaVector.magnitude >= enemy.bitePlayer)) //a la distancia minima lo ataca
        {
            rigidbody.MovePosition(transform.position + direction * enemy.speedEnemy * Time.deltaTime);
            Zombie.SetBool("NeckBite", false);
            Zombie.SetBool("Attack", true); //activa animacion de ataque 
            Zombie.SetBool("Persecution", false);
            colliderAttack.enabled=true;
            colliderBite.enabled=false;
        }
        else //if ((deltaVector.magnitude <= enemy.distancePlayer)&&(deltaVector.magnitude >= enemy.attackPlayer)) // El enemigo cambia a modo persecucion cuando sea poner la distancia al player pero no tanto, sino lo ataca
        {
            //transform.forward = Vector3.Lerp(transform.forward, direction, enemy.rotationSpeed * Time.deltaTime); // copia su angulo del player
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            rigidbody.MovePosition(transform.position + direction * enemy.speedEnemy * Time.deltaTime); // y avanza
            Zombie.SetBool("Persecution", true); //solo activa animacion de persecucion            
            Zombie.SetBool("NeckBite", false);
            Zombie.SetBool("Attack", false);
            colliderAttack.enabled=false;
            colliderBite.enabled=false;

        }
        // else// y si esta muy lejos solo camina el recorrido de waypoints
        // {
        //     Vector3 gamaVector = waypoints[currentIndex].transform.position - transform.position;
        //     Vector3 directionB = gamaVector.normalized;
        //     transform.LookAt(new Vector3(waypoints[currentIndex].transform.position.x, transform.position.y, waypoints[currentIndex].transform.position.z));
        //     //transform.forward = Vector3.Lerp(transform.forward, directionB, enemy.rotationSpeed * Time.deltaTime);
        //     transform.position += transform.forward * enemy.speedEnemy * Time.deltaTime;
            
        
        //     Zombie.SetBool("Persecution", true);
        //     if (gamaVector.magnitude <= minimumDistance)
        //     {
        //         if (currentIndex >= waypoints.Length - 1)
        //         {
        //             goBack = true;
        //         }
        //         else if (currentIndex <= 0)
        //         {
        //             goBack = false;
        //         }
        //         if (goBack)
        //         {
        //             currentIndex--;
        //         }
        //         else currentIndex++;
        //     }
        // }
    }

    // private void IsGrounded()
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, transform.forward, out hit, rangoRay))
    //     {
    //         transform.position -= Vector3.down * subir * Time.deltaTime;
    //     }
    //     RaycastHit hit2;
    //     if (!Physics.Raycast(transform.position, transform.forward, out hit2, rangoRay2))
    //     {
    //         transform.position += Vector3.down * bajar * Time.deltaTime;
    //     }
    // }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.blue;
    //     Vector3 puntoB = transform.forward * rangoRay;
    //     Gizmos.DrawRay(transform.position, puntoB);
    
    //     Gizmos.color = Color.red;
    //     Vector3 puntoC = transform.forward * rangoRay2;
    //     Gizmos.DrawRay(transform.position, puntoC);
    // }


}
