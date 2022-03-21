using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPlayer : MonoBehaviour
{

    //esto es para controlar los audios o efectos del player
    private SoundManagerPlayer soundManager;//llamando al audio manager
    private bool run = true;
    private float timePassRun = 0;
    public float audioRunEnd = 2f;//en algunos use un timer porque sino los audios en loop se empezaban a superponer y se hacia bola

    private bool walk = true;
    private float timePassWalk = 0;
    public float audioWalkEnd = 2f;

    // [Header("Fire")]



    //private bool canShoot = true;
    //[SerializeField] public float shootCooldown = 1f;
    //[SerializeField] private float timeShoot = 0;

    //public int weaponType = 1;//variable para diferenciar el sonido del arma, se controla desde el weaponcontroller


    void Start()
    {

    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }


    void Update()
    {

        //segun que tipo de arma se llama una funcion
        // if (weaponType == 1)
        // {
        //     FireGun();
        // }
        // if (weaponType == 3)
        // {
        //     FireShootgun();
        // }
        // if (weaponType == 2)
        // {
        //     KnifeAudio();
        // }



        if (Input.GetKeyDown(KeyCode.R))
        {
            soundManager.SeleccionAudio(1, 0.5f);

        }


        if ((Input.GetKey(KeyCode.W)) && (walk && run))
        {

            soundManager.SeleccionAudio(2, 0.4f);
            walk = false;

        }
        if (!walk)
        {
            timePassWalk = timePassWalk + Time.deltaTime;
        }
        if (timePassWalk > audioWalkEnd)
        {
            timePassWalk = 0;
            walk = true;
        }


        if ((Input.GetKey(KeyCode.LeftShift)) && (run && walk))
        {

            soundManager.SeleccionAudio(3, 0.9f);
            run = false;

        }
        if (!run)
        {
            timePassRun = timePassRun + Time.deltaTime;
        }
        if (timePassRun > audioRunEnd)
        {
            timePassRun = 0;
            run = true;
        }

    }


    // public void FireGun()
    // {
    //     if (canShoot)
    //     {
    //         if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Input.GetKey(KeyCode.Mouse1)))
    //         {
    //             soundManager.SeleccionAudio(0, 0.5f);
    //             canShoot = false;
    //             timeShoot = 0;
    //         }
    //     }
    //     else
    //     {
    //         timeShoot += Time.deltaTime;
    //     }
    //     if (timeShoot > shootCooldown)
    //     {
    //         canShoot = true;
    //     }
    // }

    // public void FireShootgun()
    // {
    //     if (canShoot)
    //     {
    //         if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Input.GetKey(KeyCode.Mouse1)))
    //         {
    //             soundManager.SeleccionAudio(4, 0.3f);
    //             canShoot = false;
    //             timeShoot = 0;
    //         }
    //     }
    //     else
    //     {
    //         timeShoot += Time.deltaTime;
    //     }
    //     if (timeShoot > shootCooldown)
    //     {
    //         canShoot = true;
    //     }
    // }





    // public void KnifeAudio()
    // {
    //     if (canShoot)
    //     {
    //         if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Input.GetKey(KeyCode.Mouse1)))
    //         {
    //             soundManager.SeleccionAudio(5, 0.5f);
    //             canShoot = false;
    //             timeShoot = 0;
    //         }
    //     }
    //     else
    //     {
    //         timeShoot += Time.deltaTime;
    //     }
    //     if (timeShoot > shootCooldown)
    //     {
    //         canShoot = true;
    //     }
    // }

}
