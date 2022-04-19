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
    [SerializeField] public EnemyCollision enemyCollision;

    

    
    private void Awake()
    {
    player = GameObject.Find("Player");
    rigidbody = GetComponent<Rigidbody>();
    //waypoints = GameObject.FindGameObjectsWithTag("Waypoins");
    FindObjectOfType<EnemyCollision>().OnDeath += Death;    
    }

    private void OnEnable() {
        
        this.enabled=true;//Muy importante,volver a activar el script al reinstanciar al enemigo
        Debug.Log("activar");
    }
    void Update()
    {
        Movement();       
    }


    private void Movement()
    {
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 direction = deltaVector.normalized;

        if (deltaVector.magnitude <= enemy.bitePlayer) 
        {
            Zombie.SetBool("NeckBite", true);
            Zombie.SetBool("Attack", false);//activa animacion de mordida 
            Zombie.SetBool("Persecution", false);
            colliderBite.enabled=true;
            colliderAttack.enabled=false;
        }
        else if ((deltaVector.magnitude <= enemy.attackPlayer)&&(deltaVector.magnitude >= enemy.bitePlayer)) 
        {
            rigidbody.MovePosition(transform.position + direction * enemy.speedEnemy * Time.deltaTime);
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            Zombie.SetBool("NeckBite", false);
            Zombie.SetBool("Attack", true); //activa animacion de ataque 
            Zombie.SetBool("Persecution", false);
            if(enemyCollision.haveArm)
            {
                colliderAttack.enabled=true;//
            }
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

    
    private void Death(){
        this.enabled=false;
        Debug.Log("desactivar");
    }


}
