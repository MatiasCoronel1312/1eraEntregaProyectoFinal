using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //con este activo o desactivo cada arma, lo uso como script padre
    //con la tecla 1,2,y 3 se activa o desactiva la pistola ,el cuchillo y la escopeta
    //mas adelante me gustaria agregar mas armas 
    [SerializeField] GameObject[] weapons;




    [SerializeField] int typeWeapon = 1;

    //public AudiosPlayer audioWeapon;

    //public PlayerWeaponController fireWeapon;
    void Start()
    {
        enableWeapon(0, true);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            typeWeapon = 3;
        }
        SwitchWeapon();
    }

    public void SwitchWeapon()
    {
        switch (typeWeapon)
        {
            case 1:
                enableWeapon(0, true);
                enableWeapon(1, false);
                enableWeapon(2, false);
                enableWeapon(3, true);
                enableWeapon(4, false);
                enableWeapon(5, false);
                // audioWeapon.weaponType = 1;
                // fireWeapon.weapon = 1;
                break;
            case 2:
                enableWeapon(0, false);
                enableWeapon(1, true);
                enableWeapon(2, false);
                enableWeapon(3, false);
                enableWeapon(4, true);
                enableWeapon(5, false);
                // enableWeapon(3, false);
                // audioWeapon.weaponType = 2;
                // fireWeapon.weapon = 2;

                break;
            case 3:
                enableWeapon(0, false);
                enableWeapon(1, false);
                enableWeapon(2, true);
                enableWeapon(3, false);
                enableWeapon(4, false);
                enableWeapon(5, true);
                //audioWeapon.weaponType = 3;
                //fireWeapon.weapon = 3;
                break;
        }
    }
    void enableWeapon(int posicion, bool status)
    {
        weapons[posicion].SetActive(status);
    }


}
