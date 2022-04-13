using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotgunController : PlayerWeaponController
{
    [SerializeField] private GameObject cartridge;
    [SerializeField] private Transform Recamara;
    [SerializeField] private Transform shootPoint;
    private int placeCharger;


    [Header("Animacion")]
    [SerializeField] private Animator PlayerShotgun;
    [SerializeField] GameObject mira;
    [SerializeField] GameObject effectParticles;
    [SerializeField] GameObject effectSmoke;
    [SerializeField] GameObject bulletHole;


    public event Action OnFlash;
    public LayerMask hittabletLayers;


    [Header("Audio")]
    private SoundManagerPlayer soundManager;



    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }
    void Start()
    {

    }
    protected override void Fire()

    {
        if ((canShoot) && (GameManager.InstanceAmmoGun.shotergunChargerAmmo > 0))
        {
            OnFlash?.Invoke();
            GameManager.InstanceAmmoGun.shotergunChargerAmmo--;
            PlayerShotgun.SetBool("ShotgunFire", true);
            soundManager.SeleccionAudio(4, 0.3f);
            RaycastHit hit;

            if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, rangoFire, hittabletLayers))
            {
                GameObject a = Instantiate(effectSmoke, hit.point, hit.transform.rotation);
                Destroy(a, 2f);
                GameObject bulletHoleClone = Instantiate(bulletHole, hit.point+hit.normal*0.001f, Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 4f);
            }
            
            GameObject b = Instantiate(effectParticles, shootPoint.transform.position, shootPoint.transform.rotation);
            //b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            Destroy(b, 1f);
            GameObject c = Instantiate(cartridge, Recamara.transform.position, Recamara.transform.rotation);
            c.GetComponent<Rigidbody>().AddForce(Recamara.transform.TransformDirection(Vector3.up) * 0.5f, ForceMode.Impulse);
            Destroy(c, 1.5f); 

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
            PlayerShotgun.SetBool("ShotgunFire", false);


        }
    }

    protected override void Point()

    {
        PlayerShotgun.SetBool("ShotgunPoint", true);
        mira.SetActive(true);
        timeShoot += Time.deltaTime;
    }

    protected override void UndoPoint()

    {
        PlayerShotgun.SetBool("ShotgunPoint", false);
        mira.SetActive(false);
    }



    protected override void Reload()
    {
        
        if(( GameManager.InstanceAmmoGun.shotergunAmmo > 0 ) && ( GameManager.InstanceAmmoGun.shotergunChargerAmmo < 8 ))
        {
            PlayerShotgun.SetBool("Reload", true);
            soundManager.SeleccionAudio(6, 0.6f);
            placeCharger = 8 - GameManager.InstanceAmmoGun.shotergunChargerAmmo;
            if(GameManager.InstanceAmmoGun.shotergunAmmo>placeCharger){
                GameManager.InstanceAmmoGun.shotergunAmmo-=placeCharger;
                GameManager.InstanceAmmoGun.shotergunChargerAmmo+=placeCharger;
            }else{
                GameManager.InstanceAmmoGun.shotergunChargerAmmo+=GameManager.InstanceAmmoGun.shotergunAmmo;
                GameManager.InstanceAmmoGun.shotergunAmmo=0;
            }

        }
    }
    protected override void UndoReload()
    {
        PlayerShotgun.SetBool("Reload", false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntoB = shootPoint.transform.TransformDirection(Vector3.forward) * rangoFire;
        Gizmos.DrawRay(shootPoint.transform.position, puntoB);
    }
}
