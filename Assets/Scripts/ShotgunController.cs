using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotgunController : PlayerWeaponController
{

    [SerializeField] private Transform Recamara;
    [SerializeField] private Transform shootPoint;
    private int placeCharger;


    [Header("Animacion")]
    [SerializeField] private Animator PlayerShotgun;
    [SerializeField] GameObject mira;



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
                if (hit.collider.transform.gameObject.CompareTag("Plataforma"))
                {
                    //
                    GameObject a = GameManager.instancePlayer.RequestSmoke();
                    a.SetActive(true);
                    a.transform.position = hit.point;
                    a.transform.rotation = hit.transform.rotation;
                    //
                    GameObject b = GameManager.instancePlayer.RequestBulletHole();
                    b.SetActive(true);
                    b.transform.position = hit.point + hit.normal * 0.001f;
                    b.transform.rotation = Quaternion.LookRotation(hit.normal);
                }


                if (hit.collider.transform.gameObject.CompareTag("Head"))
                {
                    hit.collider.transform.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<EnemyCollision>().BulletImpactShotgunHead();
                }
                if (hit.collider.transform.gameObject.CompareTag("BodyEnemy"))
                {
                    hit.collider.transform.parent.parent.parent.gameObject.GetComponent<EnemyCollision>().BulletImpactShotgun();
                }
                if (hit.collider.transform.gameObject.CompareTag("ArmEnemy"))
                {
                    hit.collider.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<EnemyCollision>().BulletImpactArmRShotgun();
                }
                if (hit.collider.transform.gameObject.CompareTag("ArmEnemyLeft"))
                {
                    hit.collider.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<EnemyCollision>().BulletImpactArmLShotgun();
                }


            }
            //
            GameObject d = GameManager.instancePlayer.RequestFlash();
            d.SetActive(true);
            d.transform.position = shootPoint.transform.position;
            d.transform.rotation = shootPoint.transform.rotation;
            //
            GameObject c = GameManager.instancePlayer.RequestCarShotgun();
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

        if ((GameManager.InstanceAmmoGun.shotergunAmmo > 0) && (GameManager.InstanceAmmoGun.shotergunChargerAmmo < 8))
        {
            PlayerShotgun.SetBool("Reload", true);
            soundManager.SeleccionAudio(6, 0.6f);
            placeCharger = 8 - GameManager.InstanceAmmoGun.shotergunChargerAmmo;
            if (GameManager.InstanceAmmoGun.shotergunAmmo > placeCharger)
            {
                GameManager.InstanceAmmoGun.shotergunAmmo -= placeCharger;
                GameManager.InstanceAmmoGun.shotergunChargerAmmo += placeCharger;
            }
            else
            {
                GameManager.InstanceAmmoGun.shotergunChargerAmmo += GameManager.InstanceAmmoGun.shotergunAmmo;
                GameManager.InstanceAmmoGun.shotergunAmmo = 0;
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
