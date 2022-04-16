using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    [SerializeField] private float Desactivate;
    private void OnEnable() {

        StartCoroutine(Destroy());

    }

    IEnumerator Destroy() {
        
        yield return new WaitForSeconds(Desactivate); 
        gameObject.SetActive(false);
        
    }
}
