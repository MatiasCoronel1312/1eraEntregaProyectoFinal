using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGunCharger : MonoBehaviour
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
