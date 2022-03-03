using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
     [SerializeField] GameObject[] weapons;

     public int typeWeapon=1;

     public AudiosPlayer audioWeapon;

    void Start()
    {
        enableWeapon(0, true);
    }

    // Update is called once per frame
    void Update()
    {
                if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeWeapon=1;
        }
                       if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeWeapon=2;
        }
                       if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            typeWeapon=3;
        }
        
        SwitchWeapon();
    }

    public void SwitchWeapon(){

        switch (typeWeapon){

        case 1:
            enableWeapon(0, true);
            enableWeapon(1, false);
            enableWeapon(2, false);
            audioWeapon.weaponType=1;
            break;
        case 2:
            enableWeapon(0, false);
            enableWeapon(1, true);
            enableWeapon(2, false);
            audioWeapon.weaponType=2;
            break;
        case 3:
            enableWeapon(0, false);
            enableWeapon(1, false);
            enableWeapon(2, true);
            audioWeapon.weaponType=3;
            break;
        }
    }





    void enableWeapon(int posicion, bool status)
    {
        weapons[posicion].SetActive(status);
    }
}
