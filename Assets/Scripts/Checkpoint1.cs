using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint1 : MonoBehaviour
{
    [SerializeField] GameObject zombies;
    [SerializeField] Transform spawnPoint;
    private bool spawnEnemy = true;

    public float timeSapwn;
    
private void OnTriggerExit(Collider other) {
        
        if ((other.gameObject.CompareTag("Player"))&&(spawnEnemy))
        {
            StartCoroutine(Spawn());            

        }
}

IEnumerator Spawn()
    {
        Instantiate(zombies, spawnPoint.transform.position, zombies.transform.rotation);       
        yield return new WaitForSeconds(timeSapwn); 
        Instantiate(zombies, spawnPoint.transform.position, zombies.transform.rotation);        
        spawnEnemy=false;
    }


}
