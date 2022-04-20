using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemyEvent : MonoBehaviour
{
    [SerializeField] GameObject zombies;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;
    [SerializeField] Transform spawnPoint3;
    [SerializeField] public float spawnInterval = 8f;
    [SerializeField] private bool onEvent = false ;

    private void Awake()
    {
        FindObjectOfType<EventManager>().OnEvent += SpawnEnemy;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemy()
    {

        if(!onEvent)
        {
            for (int i = 0; i < 4; i++)
        {
            float interval= Random.Range(1,spawnInterval);

            Invoke("InstantiateEnemy", interval  * 1f);
            Invoke("InstantiateEnemyRun", interval  * 0.8f);
        }
        onEvent=true;
        }

    }


    private void InstantiateEnemy()
    {
            GameObject d = GameManager.instancePlayer.RequestEnemy();
            d.SetActive(true);
            d.transform.position = spawnPoint1.transform.position;
            d.transform.rotation = spawnPoint1.transform.rotation;
    }
        private void InstantiateEnemyRun()
    {
            GameObject d = GameManager.instancePlayer.RequestEnemyRun();
            d.SetActive(true);
            d.transform.position = spawnPoint2.transform.position;
            d.transform.rotation = spawnPoint2.transform.rotation;
    }
}
