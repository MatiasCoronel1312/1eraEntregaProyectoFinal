using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;

    private bool canShoot=true;
    [SerializeField] public float shootCooldown =1f;
    [SerializeField] private float timeShoot=0;

    [SerializeField] public float rangoFire;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot){
            Fire();
        }else{
            timeShoot+=Time.deltaTime;
        }
        if(timeShoot>shootCooldown){
            canShoot=true;
        }
        

    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, rangoFire))
            {
                if(hit.transform.tag== "Enemy"){
                GameObject b = Instantiate(bullet,shootPoint.transform.position, bullet.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.TransformDirection(Vector3.forward)*10f, ForceMode.Impulse);
                Destroy(b, 5f);
                }
                canShoot=false;
                timeShoot=0;
            }
        }
    }
    private void OnDrawGizmos() {
        if(canShoot){
            Gizmos.color= Color.red;
            Vector3 puntoB = shootPoint.transform.TransformDirection(Vector3.forward)*rangoFire;
            Gizmos.DrawRay(shootPoint.transform.position, puntoB);
        }
    }

}
