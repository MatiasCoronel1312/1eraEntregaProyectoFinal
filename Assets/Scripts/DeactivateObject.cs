using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour// para desactivar object pooling , igual que con los cartuchos pero sin necesidad de reseear el Rigi ( por ejemplo Sangre, humo, bulletHole etc)
{
    [SerializeField] private float Desactivate;
    private void OnEnable() {

        StartCoroutine(Destroy());//al activar se llama una corrutina 

    }

    IEnumerator Destroy() {
        
        yield return new WaitForSeconds(Desactivate); 
        gameObject.SetActive(false);
        
    }
}
