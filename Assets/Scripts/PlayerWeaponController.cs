using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeaponController : MonoBehaviour
{
       [SerializeField] protected float rangoFire= 10f;
    [SerializeField] protected bool canShoot = true;
    [SerializeField] protected float timeShoot = 0;
    [SerializeField] protected float shootCooldown = 1f;
    
    void Start()
    {

    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.Mouse0)) && (Input.GetKey(KeyCode.Mouse1)))
        {
            Fire();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            UndoFire();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            UndoReload();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Point();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            UndoPoint();
        }


    }
    protected virtual void Fire()
    {
       // Debug.Log("Disparo");
    }
    protected virtual void UndoFire()
    {
        //Debug.Log("Suelto Disparo");
    }
    protected virtual void Point()
    {
        //Debug.Log("Apunto");
    }
    protected virtual void UndoPoint()
    {
        //Debug.Log("Dejo apuntar");
    }
    protected virtual void Reload()
    {
        Debug.Log("Recargo");
    }
    protected virtual void UndoReload()
    {
        Debug.Log("Suelto Recargar");
    }


}
