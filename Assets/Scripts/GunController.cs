using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : PlayerWeaponController
{
    
    
    [SerializeField] private Transform shootPoint;

    [SerializeField] private Transform Recamara;
    private int placeCharger;


    [Header("Animacion")]
    [SerializeField] private Animator PlayerShooter;
    [SerializeField] GameObject mira;
    



    public event Action OnFlash;
    public LayerMask hittabletLayers;

    [Header("Audio")]
    private SoundManagerPlayer soundManager;



    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
        //gunCharger = GameManager.InstanceAmmoGun.gunChargerAmmo;
        //gunAmmo = GameManager.InstanceAmmoGun.gunAmmo;
    }
    void Start()
    {
        
        

    }
    protected override void Fire()

    {
        if ((canShoot) && (GameManager.InstanceAmmoGun.gunChargerAmmo > 0))
        {
            OnFlash?.Invoke();
            GameManager.InstanceAmmoGun.gunChargerAmmo--;
            PlayerShooter.SetBool("FireGun", true);
            soundManager.SeleccionAudio(0, 0.5f);
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, rangoFire, hittabletLayers))
            {
                GameObject a = GameManager.instancePlayer.RequestSmoke();
                a.SetActive(true);
                a.transform.position = hit.point;
                a.transform.rotation = hit.transform.rotation;
                //
                GameObject b = GameManager.instancePlayer.RequestBulletHole();
                b.SetActive(true);
                b.transform.position = hit.point+hit.normal*0.001f;
                b.transform.rotation = Quaternion.LookRotation(hit.normal);
            }
            //
            GameObject d = GameManager.instancePlayer.RequestFlash();
            d.SetActive(true);
            d.transform.position = shootPoint.transform.position;
            d.transform.rotation = shootPoint.transform.rotation;
            //
            GameObject c = GameManager.instancePlayer.RequestCartridge();
            c.SetActive(true);
            c.transform.position = Recamara.transform.position; 
            c.GetComponent<Rigidbody>().AddForce(Recamara.transform.TransformDirection(Vector3.up) * 0.8f, ForceMode.Impulse);
                        
                    
                    
                            
            

            canShoot = false;
            timeShoot = 0;
        }

        if (timeShoot > shootCooldown)
        {
            canShoot = true;
        }
    }
    protected override void UndoFire()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            PlayerShooter.SetBool("FireGun", false);


        }
    }

    protected override void Point()

    {
        PlayerShooter.SetBool("Point", true);
        mira.SetActive(true);
        timeShoot += Time.deltaTime;
    }

    protected override void UndoPoint()

    {
        PlayerShooter.SetBool("Point", false);
        mira.SetActive(false);


    }



    protected override void Reload()
    {
        if(( GameManager.InstanceAmmoGun.gunAmmo > 0 ) && ( GameManager.InstanceAmmoGun.gunChargerAmmo < 17 ))
        {
            //Debug.Log("anda!");
            PlayerShooter.SetBool("Reload", true);
            soundManager.SeleccionAudio(1, 0.5f);
            placeCharger = 17 - GameManager.InstanceAmmoGun.gunChargerAmmo;
            if(GameManager.InstanceAmmoGun.gunAmmo>placeCharger){
                GameManager.InstanceAmmoGun.gunAmmo-=placeCharger;
                GameManager.InstanceAmmoGun.gunChargerAmmo+=placeCharger;
            }else{
                GameManager.InstanceAmmoGun.gunChargerAmmo+=GameManager.InstanceAmmoGun.gunAmmo;
                GameManager.InstanceAmmoGun.gunAmmo=0;
            }

        }

    }

    protected override void UndoReload()


    {
        PlayerShooter.SetBool("Reload", false);

    }

    

    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntoB = shootPoint.transform.TransformDirection(Vector3.forward) * rangoFire;
        Gizmos.DrawRay(shootPoint.transform.position, puntoB);
    }
}
