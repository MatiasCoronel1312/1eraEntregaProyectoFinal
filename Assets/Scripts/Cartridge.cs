using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour// script para desactivar el cartucho 
{
    private new Rigidbody rigidbody;

    [SerializeField] private float DestroyCartridge;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()//apenas se activa se llama a una corrutina y con una variable se ajusta el tiempo que dura antes de desactivarla de nuevo
    {

        StartCoroutine(Destroy());

        rigidbody.velocity = new Vector3(0f, 0f, 0f);// y se resetea el rigidbody para que al activar de nuevo se pueda generar el impulso, mucho muy importante para que mantenga el efecto de que salta del arma
        rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);// 
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));


    }

    IEnumerator Destroy()
    {

        yield return new WaitForSeconds(DestroyCartridge); //Desactiva cartucho 1,5seg
        gameObject.SetActive(false);

    }

}
