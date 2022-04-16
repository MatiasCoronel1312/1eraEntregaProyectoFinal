using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : PlayerWeaponController
{

    [Header("Animacion")]
    [SerializeField] private Animator PlayerKnife;
    //[SerializeField] GameObject playerKnife;
    [SerializeField] Collider colliderKnife;    

    [Header("Audio")]
    private SoundManagerPlayer soundManager;
    


    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
        
        //collider = playerKnife.GetComponent<Collider>();
    }
    void Start()
    {

    }
    protected override void Fire()

    {
        if (canShoot)
        {
            PlayerKnife.SetBool("KnifeAttack", true);
            soundManager.SeleccionAudio(5, 0.5f);
            colliderKnife.enabled=true;
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
            PlayerKnife.SetBool("KnifeAttack", false);
            colliderKnife.enabled=false;

        }
    }

    protected override void Point()

    {
        PlayerKnife.SetBool("KnifePoint", true);
        timeShoot += Time.deltaTime;
    }

    protected override void UndoPoint()

    {
        PlayerKnife.SetBool("KnifePoint", false);   
    }



    // protected override void Reload()
    // {
    //     PlayerKnife.SetBool("ReloadShotgun", true);
    // }
    // protected override void UndoReload()
    // {
    //     PlayerKnife.SetBool("ReloadShotgun", false);
    // }



}
