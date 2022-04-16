using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Zombie2 : MonoBehaviour
{

    
    [SerializeField] public GameObject [] waypoints;
    private int currentIndex = 0;
    [SerializeField] float minimumDistance;
    private bool goBack = false;
    [SerializeField] protected EnemyData enemy;
    [SerializeField] private Animator Zombie;     
    [SerializeField] private GameObject player;
    
    private CharacterController ccEnemy;
    [SerializeField] GameObject AttackEnemy;
    [SerializeField] Collider colliderAttack;  

    [SerializeField] public EnemyCollision zombieMove;
    private Vector3 velocidad;
    public float bajar;
    

    
    private void Awake()
    {
        
        player = GameObject.Find("Player");
        waypoints = GameObject.FindGameObjectsWithTag("Waypoins1");
        //AttackEnemy = GameObject.FindGameObjectsWithTag("AttackEnemy");
        
    
    }

    private void Start() 
    {
        ccEnemy = GetComponent<CharacterController>();
        colliderAttack = AttackEnemy.GetComponent<Collider>();
    }

    
    void Update()
    {
        Movement();
        if(zombieMove.isDeath){
            this.enabled=false;
        }
        IsGrounder();
        
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
        }
        else if (deltaVector.magnitude <= enemy.attackPlayer) //a la distancia minima lo ataca
        {
            MoveEnemy(Vector3.forward);
            Zombie.SetBool("NeckBite", false);
            Zombie.SetBool("Attack", true); //activa animacion de ataque 
            Zombie.SetBool("Persecution", false);
            colliderAttack.enabled=true;
        }
        else if ((deltaVector.magnitude <= enemy.distancePlayer)&&(deltaVector.magnitude >= enemy.attackPlayer)) // El enemigo cambia a modo persecucion cuando sea poner la distancia al player pero no tanto, sino lo ataca
        {
            //transform.forward = Vector3.Lerp(transform.forward, direction, enemy.rotationSpeed * Time.deltaTime); // copia su angulo del player
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            MoveEnemy(Vector3.forward); // y avanza
            Zombie.SetBool("Persecution", true); //solo activa animacion de persecucion
            colliderAttack.enabled=false;
            Zombie.SetBool("NeckBite", false);
            Zombie.SetBool("Attack", false);

        }
        else// y si esta muy lejos solo camina el recorrido de waypoints
        {
            Vector3 gamaVector = waypoints[currentIndex].transform.position - transform.position;
            Vector3 directionB = gamaVector.normalized;
            transform.LookAt(new Vector3(waypoints[currentIndex].transform.position.x, transform.position.y, waypoints[currentIndex].transform.position.z));
            //transform.forward = Vector3.Lerp(transform.forward, directionB, enemy.rotationSpeed * Time.deltaTime);
            MoveEnemy(Vector3.forward);
            
        
            Zombie.SetBool("Persecution", true);
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

    private void IsGrounder(){
        // if (!ccEnemy.isGrounded)

        // {
        //     velocidad.y += bajar * Time.deltaTime;

        //     ccEnemy.Move(velocidad * Time.deltaTime);
        // }
        ccEnemy.Move(Vector3.down * bajar * Time.deltaTime);


    }
    private void MoveEnemy(Vector3 direccion)
    {
        
        ccEnemy.Move(enemy.speedEnemy * Time.deltaTime * transform.TransformDirection(direccion));
        
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
