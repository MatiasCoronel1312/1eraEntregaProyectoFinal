using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : PlayerWeaponController
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;

    [Header("Animacion")]
    [SerializeField] private Animator PlayerShooter;
    [SerializeField] GameObject mira;

    public event Action OnFlash;

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
        if ((canShoot) && (GameManager.InstanceAmmoGun.gunAmmo > 0))
        {
             OnFlash?.Invoke();
            GameManager.InstanceAmmoGun.gunAmmo--;
            PlayerShooter.SetBool("FireGun", true);
            soundManager.SeleccionAudio(0, 0.5f);
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, rangoFire))
            {
                GameObject b = Instantiate(bullet, shootPoint.transform.position, bullet.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
                Destroy(b, 5f);
            }

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

        //PlayerShooter.SetBool("Reload", true);
        soundManager.SeleccionAudio(1, 0.5f);

    }

    protected override void UndoReload()


    {
        //PlayerShooter.SetBool("Reload", false);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntoB = shootPoint.transform.TransformDirection(Vector3.forward) * rangoFire;
        Gizmos.DrawRay(shootPoint.transform.position, puntoB);
    }
}
