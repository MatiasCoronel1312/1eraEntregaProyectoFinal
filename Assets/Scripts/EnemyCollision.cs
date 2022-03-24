using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private float timer = 0;
    public bool isDeath = false;

    [SerializeField] public float timerAnimation = 2f;
    [SerializeField] private Animator Zombie;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
        {
            timer = timer + Time.deltaTime;
            Debug.Log("Timer Activado");
        }
        if (timer >= timerAnimation)
        {
            Debug.Log("death Activado");
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            isDeath = true;
            Zombie.SetBool("IsDeath", true);

        }
    }
}
