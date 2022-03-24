using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemyEvent : MonoBehaviour
{
    [SerializeField] GameObject zombies;
    [SerializeField] Transform spawnPoint;
    [SerializeField] public float spawnInterval = 8f;

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

        for (int i = 0; i < 20; i++)
        {

            Invoke("InstantiateEnemy", spawnInterval * 1f);
        }
        gameObject.SetActive(false);

    }


    private void InstantiateEnemy()
    {
        Instantiate(zombies, spawnPoint.transform.position, zombies.transform.rotation);
    }
}
