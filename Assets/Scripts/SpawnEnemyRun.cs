using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyRun : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    private bool spawnEnemy = true;

    [SerializeField] private float timeSpawn;
    [SerializeField] private int enemies;
    
private void OnTriggerExit(Collider other) {
        
        if ((other.gameObject.CompareTag("Player"))&&(spawnEnemy))
        {
            spawnEnemy=false;
            StartCoroutine(Spawn());            

        }
}

IEnumerator Spawn()
    {
        for(int i=0; i < enemies ; i++)
        {
        SpawnEnemy();       
        yield return new WaitForSeconds(timeSpawn); 
        }
        
    }

    private void SpawnEnemy(){
        GameObject b = GameManager.instancePlayer.RequestEnemyRun();
        b.SetActive(true);
        b.transform.position = spawnPoint.transform.position;
        b.transform.rotation = transform.rotation;
    }


}
