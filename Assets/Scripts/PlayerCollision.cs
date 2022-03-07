using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    
//este script solo reinicia la escena despues de perder
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Nivel1");
        }
    }
}
