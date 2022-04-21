using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoShotergun : MonoBehaviour//script para el panel que marca la cantidad de balas total de la escopeta
{
    public Text ammoSGText;

    void Update()
    {
        AmmoShotgun();
    }

    public void AmmoShotgun()
    {
        ammoSGText.text = GameManager.InstanceAmmoGun.shotergunAmmo.ToString();
    }
}
