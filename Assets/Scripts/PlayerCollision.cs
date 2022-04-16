using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event Action OnDamage;
    public LifePlayer lifeBar;
    public float damageAmount = 2f ;

    [Header("Audio")]
    private SoundManagerPlayer soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }
    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("AttackEnemy"))
        {
            OnDamage?.Invoke();
            lifeBar.LifeCurrent-= damageAmount;
            if(lifeBar.LifeCurrent<=0)
            {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Nivel1");
            }
        }
        

        
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            //Debug.Log(other.gameObject.name);
            CheckpointsManager managerCP = other.transform.parent.GetComponent<CheckpointsManager>();
            managerCP.FindCheckPoint(other.gameObject.name);
        }

        if (other.gameObject.CompareTag("GunAmmo"))
        {
            Debug.Log(other.gameObject.name);
            GameManager.InstanceAmmoGun.gunAmmo += other.gameObject.GetComponent<AmmoGunBox>().ammo;
            Destroy(other.gameObject);
            soundManager.SeleccionAudio(7, 0.2f);        }
    

        if (other.gameObject.CompareTag("ShotergunAmmo"))
        {
            Debug.Log(other.gameObject.name);
            GameManager.InstanceAmmoGun.shotergunAmmo += other.gameObject.GetComponent<AmmoShotergunBox>().ammoShotergun;
            Destroy(other.gameObject);
            soundManager.SeleccionAudio(7, 0.2f);        }


        if (other.gameObject.CompareTag("Medicine"))
        {
            Debug.Log(other.gameObject.name);
            lifeBar.LifeCurrent+= 25;
            Destroy(other.gameObject);
            soundManager.SeleccionAudio(7, 0.2f);        }

            if (other.gameObject.CompareTag("AttackEnemy"))
        {
            OnDamage?.Invoke();
            lifeBar.LifeCurrent-= damageAmount;
            if(lifeBar.LifeCurrent<=0)
            {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Nivel1");
            }
        }
    }
}
