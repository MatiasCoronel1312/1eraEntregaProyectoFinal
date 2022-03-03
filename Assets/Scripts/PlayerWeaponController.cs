using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private GameObject bulletShootgun;
    [SerializeField] private Transform shootgunPoint;

    private bool canShoot = true;
    [SerializeField] public float shootCooldown = 1f;
    [SerializeField] private float timeShoot = 0;

    [SerializeField] public float rangoFire;

    public int weapon = 1;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (weapon == 1)
        {

            FireGun();
        }
        if (weapon == 3)
        {

            FireShootgun();
        }



    }

    private void FireGun()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;
                if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, rangoFire))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        GameObject b = Instantiate(bullet, shootPoint.transform.position, bullet.transform.rotation);
                        b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
                        Destroy(b, 5f);
                    }
                    canShoot = false;
                    timeShoot = 0;
                }
            }
        }
        else
        {
            timeShoot += Time.deltaTime;
        }
        if (timeShoot > shootCooldown)
        {
            canShoot = true;
        }
    }
    private void OnDrawGizmos()
    {
        if (weapon == 1)
        {

            if (canShoot)
            {
                Gizmos.color = Color.red;
                Vector3 puntoB = shootPoint.transform.TransformDirection(Vector3.forward) * rangoFire;
                Gizmos.DrawRay(shootPoint.transform.position, puntoB);
            }
        }
        if (weapon == 3)
        {

            if (canShoot)
            {
                Gizmos.color = Color.red;
                Vector3 puntoB = shootgunPoint.transform.TransformDirection(Vector3.forward) * rangoFire;
                Gizmos.DrawRay(shootgunPoint.transform.position, puntoB);
            }
        }

    }


    public void FireShootgun()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;
                if (Physics.Raycast(shootgunPoint.transform.position, shootgunPoint.transform.forward, out hit, rangoFire))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        GameObject c = Instantiate(bulletShootgun, shootgunPoint.transform.position, bulletShootgun.transform.rotation);
                        c.GetComponent<Rigidbody>().AddForce(shootgunPoint.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
                        Destroy(c, 6f);
                    }
                    canShoot = false;
                    timeShoot = 0;
                }
            }
        }
        else
        {
            timeShoot += Time.deltaTime;
        }
        if (timeShoot > shootCooldown)
        {
            canShoot = true;
        }
    }

}
