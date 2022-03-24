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
