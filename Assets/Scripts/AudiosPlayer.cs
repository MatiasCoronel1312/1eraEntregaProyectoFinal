using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPlayer : MonoBehaviour
{
    private SoundManagerPlayer soundManager;
    private bool run = true;
    private float timePassRun = 0;
    public float audioRunEnd = 2f;

    private bool walk = true;
    private float timePassWalk = 0;
    public float audioWalkEnd = 2f;

    [Header("Fire")]

    private bool canShoot = true;
    [SerializeField] public float shootCooldown = 1f;
    [SerializeField] private float timeShoot = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot){
            Fire();
        }else{
              timeShoot+=Time.deltaTime;
           }
        if(timeShoot>shootCooldown){
            canShoot=true;
        }

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

    private void Fire(){
            if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Input.GetKey(KeyCode.Mouse1)))
        {
            soundManager.SeleccionAudio(0, 0.5f);
            canShoot = false;
            timeShoot = 0;
        }
        
    }
}
