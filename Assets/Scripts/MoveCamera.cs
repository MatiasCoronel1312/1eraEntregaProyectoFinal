using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   
    [SerializeField] public float timeEffect = 0.05f;
    [SerializeField] public int attackEffect= 3;
    private Vector3 direction = new Vector3(0, 0, 1);
     [SerializeField] float speed = 2f;
    private bool isRunMove = false;
    public GunController gunController;
    public ShotgunController shotgunController;

    private void Awake()
    {
         gunController.OnFlash += OnFlashEvent;
         shotgunController.OnFlash += OnFlashEvent;
         FindObjectOfType<PlayerCollision>().OnDamage += OnDamageEvent;
         
    }
    
    void Update()
    {

    }

     IEnumerator Flash()
    {
       isRunMove = true;
        
        transform.Translate(speed * Time.deltaTime * direction);
         yield return new WaitForSeconds(timeEffect); 

        transform.Translate(speed * Time.deltaTime * -direction);
       isRunMove = false;
    }

    public void OnFlashEvent()
    {
       
        if (!isRunMove)
        {
            StartCoroutine(Flash());
        }
    }

        IEnumerator Damage()
    {
       isRunMove = true;
        for( int i = 0; i < attackEffect ; i++)
    {    transform.Translate(speed * Time.deltaTime * direction);
         yield return new WaitForSeconds(timeEffect); 
        transform.Translate(speed * Time.deltaTime * -direction);
        yield return new WaitForSeconds(timeEffect);
         }
       isRunMove = false;
    }

    public void OnDamageEvent()
    {
        if (!isRunMove)
        {
            StartCoroutine(Damage());
        }
    }
}
