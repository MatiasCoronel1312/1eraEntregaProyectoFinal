using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGunCharger : MonoBehaviour//script para el panel que marca la cantidad de balas en el cargador de la pistola
{
    public Text ammoChargerText;

    void Update()
    {
        AmmoGun();
    }

    public void AmmoGun()
    {
        ammoChargerText.text = GameManager.InstanceAmmoGun.gunChargerAmmo.ToString();
    }
}
