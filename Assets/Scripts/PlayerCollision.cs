using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public LifePlayer lifeBar;
    public float damageAmount = 2f ;
    
//este script solo reinicia la escena despues de perder
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lifeBar.LifeCurrent-= damageAmount;
            if(lifeBar.LifeCurrent==0)
            {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Nivel1");
            }
        }
        

        
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log(other.gameObject.name);
           
            CheckpointsManager managerCP = other.transform.parent.GetComponent<CheckpointsManager>();
            managerCP.FindCheckPoint(other.gameObject.name);
        }

        if (other.gameObject.CompareTag("GunAmmo"))
        {
            Debug.Log(other.gameObject.name);
            GameManager.InstanceAmmoGun.gunAmmo += other.gameObject.GetComponent<AmmoGunBox>().ammo;
            Destroy(other.gameObject);        }
    }
}
