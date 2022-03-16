using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGuns : MonoBehaviour
{
    public Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmoGun();
    }

    public void AmmoGun()
    {
        ammoText.text = GameManager.InstanceAmmoGun.gunAmmo.ToString();
    }
}
