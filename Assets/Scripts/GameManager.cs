using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancePlayer;

    
    public static GameManager InstanceAmmoGun { get; private set;}
    public int gunAmmo =17;

    public int lastSP;


    private void Awake() {
        if (instancePlayer==null){
            instancePlayer=this;
            DontDestroyOnLoad(gameObject);
            //positionPlayer= new Vector3 (0f,0.6f,100f);//posicion inicial del player, despues de pasar por algun checkpoint se instacia la variable


        }else{
            Destroy(gameObject);
        }
        InstanceAmmoGun = this;

    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
