using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FlashShoot : MonoBehaviour//script que controla el efecto de flash al disparar conjuntamente con el fogonazo (particulas) y e la llama con un event , tambien uso un a corrutina para controlar la duracion del efecto 
{
    private PostProcessVolume globalVolume;
    private Bloom flashEffect;
    [SerializeField] public float timeEffect = 0.1f;
    private bool isRunFlash = false;
    public GunController gunController;
    public ShotgunController shotgunController;

    private void Awake()
    {
    

        
        globalVolume = GetComponent<PostProcessVolume>();
        globalVolume.profile.TryGetSettings(out flashEffect);
        //FindObjectOfType<GunController>().OnFlash += OnFlashEvent;
        gunController.OnFlash += OnFlashEvent;
        shotgunController.OnFlash += OnFlashEvent;
        //FindObjectOfType<PlayerCollision>().OnDamage += OnDamageEvent;


    }
    
    void Update()
    {

    }
    IEnumerator Flash()
    {
        isRunFlash = true;
        
        flashEffect.active = true;
        yield return new WaitForSeconds(timeEffect); 

        flashEffect.active = false;
        isRunFlash = false;
    }

    public void OnFlashEvent()
    {
        if (!isRunFlash)
        {
            StartCoroutine(Flash());
        }
    }
}
