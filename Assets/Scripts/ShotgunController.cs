using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : PlayerWeaponController
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;


    [Header("Animacion")]
    [SerializeField] private Animator PlayerShotgun;
    [SerializeField] GameObject mira;

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
            GameManager.InstanceAmmoGun.gunAmmo--;
            PlayerShotgun.SetBool("ShotgunFire", true);
            soundManager.SeleccionAudio(4, 0.3f);
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



    // protected override void Reload()
    // {
    //     PlayerShotgun.SetBool("ReloadShotgun", true);
    // }
    // protected override void UndoReload()
    // {
    //     PlayerShotgun.SetBool("ReloadShotgun", false);
    // }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntoB = shootPoint.transform.TransformDirection(Vector3.forward) * rangoFire;
        Gizmos.DrawRay(shootPoint.transform.position, puntoB);
    }
}
