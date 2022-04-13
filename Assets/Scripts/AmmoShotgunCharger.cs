using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoShotgunCharger : MonoBehaviour
{
    public Text ammoSGText;
    // Start is called before the first frame update
    void Update()
    {
        AmmoShotgun();
    }

    public void AmmoShotgun()
    {
        ammoSGText.text = GameManager.InstanceAmmoGun.shotergunChargerAmmo.ToString();
    }
}
