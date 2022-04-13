using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoShotergun : MonoBehaviour
{
    public Text ammoSGText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmoShotgun();
    }

    public void AmmoShotgun()
    {
        ammoSGText.text = GameManager.InstanceAmmoGun.shotergunAmmo.ToString();
    }
}
