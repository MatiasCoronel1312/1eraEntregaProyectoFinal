using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    private new Rigidbody rigidbody;

    [SerializeField] private float DestroyCartridge;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {

        StartCoroutine(Destroy());

        rigidbody.velocity = new Vector3 (0f,0f,0f); 
        rigidbody.angularVelocity = new Vector3(0f,0f,0f);
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));


    }

    IEnumerator Destroy() {
        
        yield return new WaitForSeconds(DestroyCartridge); //Desactiva cartucho 1,5seg
        gameObject.SetActive(false);
        
    }
    
}
