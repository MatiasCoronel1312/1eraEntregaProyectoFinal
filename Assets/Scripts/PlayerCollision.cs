using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event Action OnDamage;//este evento se llama en la secuencia final para que ya no pueda perder vida y no muera
    public LifePlayer lifeBar;
    public float damageAmount = 2f;
    public bool lifeDamage = true;
    [SerializeField] private GameObject wound;// es la posicion de donde le sale la sangre

    [Header("Audio")]
    private SoundManagerPlayer soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }

    // private void OnCollisionEnter(Collision other) {

    // }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Checkpoint"))// para cargar la posicon del checkpoint
        {
            CheckpointsManager managerCP = other.transform.parent.GetComponent<CheckpointsManager>();
            managerCP.FindCheckPoint(other.gameObject.name);
        }

        if (other.gameObject.CompareTag("GunAmmo"))//para agarrar balas
        {
            //Debug.Log(other.gameObject.name);
            GameManager.InstanceAmmoGun.gunAmmo += other.gameObject.GetComponent<AmmoGunBox>().ammo;
            Destroy(other.gameObject);
            soundManager.SeleccionAudio(7, 0.2f);
        }


        if (other.gameObject.CompareTag("ShotergunAmmo"))
        {
            //Debug.Log(other.gameObject.name);
            GameManager.InstanceAmmoGun.shotergunAmmo += other.gameObject.GetComponent<AmmoShotergunBox>().ammoShotergun;
            Destroy(other.gameObject);
            soundManager.SeleccionAudio(7, 0.2f);
        }


        if (other.gameObject.CompareTag("Medicine"))//medicina
        {
            Debug.Log(other.gameObject.name);
            lifeBar.LifeCurrent += 25;
            Destroy(other.gameObject);
            soundManager.SeleccionAudio(7, 0.2f);
        }

        if (lifeDamage)// si no esta en la secuencia final
        {
            if (other.gameObject.CompareTag("Head") || other.gameObject.CompareTag("ArmEnemy") || other.gameObject.CompareTag("ArmEnemyLeft"))
                //se puede lastimar que te toque con la mano o con la cabeza(mordida)
            {
                GameObject b = GameManager.instancePlayer.RequestBlood();//se instancia sangre
                b.SetActive(true);
                b.transform.position = wound.transform.position;
                b.transform.rotation = wound.transform.rotation;
                OnDamage?.Invoke();
                lifeBar.LifeCurrent -= damageAmount;//se resta vida y si es igual a cero se reinicia
                if (lifeBar.LifeCurrent <= 0)
                {
                    Debug.Log("Game Over");
                    SceneManager.LoadScene("Nivel1");
                }
            }
        }
    }
}
