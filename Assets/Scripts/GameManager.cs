using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancePlayer;

    
    public static GameManager InstanceAmmoGun { get; private set;}

    public int gunAmmo =0;

    public int gunChargerAmmo =17;
    
    public int shotergunAmmo =0;
    
    public int shotergunChargerAmmo =8;

    public int lastSP;


    private void Awake() {
        if (instancePlayer==null){
            instancePlayer=this;
            DontDestroyOnLoad(gameObject);
            


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
