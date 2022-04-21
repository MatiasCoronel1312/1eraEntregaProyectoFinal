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




    void Start()
    {

    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }


    void Update()
    {

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



}
