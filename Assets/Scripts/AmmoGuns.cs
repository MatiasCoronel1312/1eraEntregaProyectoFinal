using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGuns : MonoBehaviour//script para el panel que marca la cantidad de balas total de la pistola
{
    public Text ammoText;

    void Update()
    {
        AmmoGun();
    }

    public void AmmoGun()
    {
        ammoText.text = GameManager.InstanceAmmoGun.gunAmmo.ToString();
    }
}
