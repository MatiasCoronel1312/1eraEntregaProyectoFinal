using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint1 : MonoBehaviour
{
    [SerializeField] GameObject zombies;
    [SerializeField] Transform spawnPoint;
    private bool spawnEnemy = true;

    [SerializeField] public float timeSpawn;
    
private void OnTriggerExit(Collider other) {
        
        if ((other.gameObject.CompareTag("Player"))&&(spawnEnemy))
        {
            spawnEnemy=false;
            StartCoroutine(Spawn());            

        }
}

IEnumerator Spawn()
    {
        SpawnEnemy();       
        yield return new WaitForSeconds(timeSpawn); 
        SpawnEnemy();        
        
    }

    private void SpawnEnemy(){
        GameObject b = GameManager.instancePlayer.RequestEnemy();
        b.SetActive(true);
        b.transform.position = spawnPoint.transform.position;
        b.transform.rotation = transform.rotation;
    }


}
