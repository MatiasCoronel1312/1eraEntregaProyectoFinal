using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
     [SerializeField] GameObject[] weapons;

    void Start()
    {
        enableWeapon(0, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enableWeapon(0, true);
            enableWeapon(1, false);
            enableWeapon(2, false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enableWeapon(0, false);
            enableWeapon(1, true);
            enableWeapon(2, false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            enableWeapon(0, false);
            enableWeapon(1, false);
            enableWeapon(2, true);
        }
    }
    void enableWeapon(int posicion, bool status)
    {
        weapons[posicion].SetActive(status);
    }
}
