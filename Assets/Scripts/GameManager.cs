using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancePlayer;    
    public static GameManager InstanceAmmoGun { get; private set;}

    
    [SerializeField] private int cartridgePool; //cantidad de cartuchos en el pooling, uso la misma variable para el efecto del fogonazo, el bullet hole y el humo
    [SerializeField] private Transform Recamara;//uso este Game Object como padre para guardar a todos los pooling
    [SerializeField] private List<GameObject> cartridgeList;//lista de casquillos de la pistola
    [SerializeField] private GameObject cartridge;
    [SerializeField] private List<GameObject> carShotgunList;//lista de cartuchoos de la escopeta
    [SerializeField] private GameObject carShotgun;


    [SerializeField] private List<GameObject> FlashList;
    [SerializeField] private GameObject flashParticles;
    

    [SerializeField] private List<GameObject> bulletHoleList;
    [SerializeField] private GameObject bulletHole;

    [SerializeField] private List<GameObject> SmokeList;
    [SerializeField] private GameObject SmokeParticles;


    //ENEMY

    [SerializeField] private List<GameObject> bloodList;//
    [SerializeField] private Transform ContenedorEnemy;//
    [SerializeField] private int bloodPool; //cantidad de Particula Sangre
    [SerializeField] private GameObject blood;
    [SerializeField] private List<GameObject> meltingList;//
    [SerializeField] private GameObject melting;
    [SerializeField] private List<GameObject> enemyList;//
    [SerializeField] private int enemyPool; //cantidad de Enemigos
    [SerializeField] private GameObject enemy;



    [Header("Ammo Current")]
    

    public int gunAmmo =0;

    public int gunChargerAmmo =17;
    
    public int shotergunAmmo =0;
    
    public int shotergunChargerAmmo =8;

    public int lastSP;


    private void Awake() {
        if (instancePlayer==null){
            instancePlayer=this;
            DontDestroyOnLoad(gameObject);
            


        }else{
            Destroy(gameObject);
        }
        InstanceAmmoGun = this;

    }
    void Start()
    {
        AddCartridgeToPool(cartridgePool);
        AddCarShotgunToPool(cartridgePool);
        AddBulletHoleToPool(cartridgePool);
        AddFlashToPool(cartridgePool);
        AddSmokeToPool(cartridgePool);
        AddBloodToPool(bloodPool);
        AddMeltingToPool(bloodPool);
        AddEnemyToPool(enemyPool);
    }


    void Update()
    {
        
    }

    private void AddCartridgeToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(cartridge);
            c.SetActive(false);
            cartridgeList.Add(c);
            c.transform.parent= Recamara; 
        }
    }

    private void AddCarShotgunToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(carShotgun);
            c.SetActive(false);
            carShotgunList.Add(c);
            c.transform.parent= Recamara; 
        }
    }

    private void AddFlashToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(flashParticles);
            c.SetActive(false);
            FlashList.Add(c);
            c.transform.parent= Recamara; 
        }
    }

    private void AddSmokeToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(SmokeParticles);
            c.SetActive(false);
            SmokeList.Add(c);
            c.transform.parent= Recamara; 
        }
    }

    private void AddBulletHoleToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(bulletHole);
            c.SetActive(false);
            bulletHoleList.Add(c);
            c.transform.parent= Recamara; 
        }
    }

    private void AddBloodToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(blood);
            c.SetActive(false);
            bloodList.Add(c);
            c.transform.parent= ContenedorEnemy; 
        }
    }

    private void AddMeltingToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject c = Instantiate(melting);
            c.SetActive(false);
            meltingList.Add(c);
            c.transform.parent= ContenedorEnemy; 
        }
    }




private void AddEnemyToPool(int amount)
    {
        for(int i =0; i<amount; i++)
        {
            GameObject e = Instantiate(enemy);
            e.SetActive(false);
            enemyList.Add(e);
            e.transform.parent= ContenedorEnemy; 
        }
    }



    public GameObject RequestCartridge()
    {
            

        for(int i =0 ; i < cartridgeList.Count ; i++)
        {
            if(!cartridgeList[i].activeInHierarchy)
            {
                return cartridgeList[i];
            }
            
        }
            return null;
    }

    public GameObject RequestCarShotgun()
    {
            

        for(int i =0 ; i < carShotgunList.Count ; i++)
        {
            if(!carShotgunList[i].activeInHierarchy)
            {
                return carShotgunList[i];
            }
            
        }
            return null;
    }
    public GameObject RequestFlash()
    {
            

        for(int i =0 ; i < FlashList.Count ; i++)
        {
            if(!FlashList[i].activeInHierarchy)
            {
                return FlashList[i];
            }
            
        }
            return null;
    }
    public GameObject RequestSmoke()
    {
            

        for(int i =0 ; i < SmokeList.Count ; i++)
        {
            if(!SmokeList[i].activeInHierarchy)
            {
                return SmokeList[i];
            }
            
        }
            return null;
    }
    public GameObject RequestBulletHole()
    {
            

        for(int i =0 ; i < bulletHoleList.Count ; i++)
        {
            if(!bulletHoleList[i].activeInHierarchy)
            {
                return bulletHoleList[i];
            }
            
        }
            return null;
    }

    public GameObject RequestBlood()
    {
            

        for(int i =0 ; i < bloodList.Count ; i++)
        {
            if(!bloodList[i].activeInHierarchy)
            {
                return bloodList[i];
            }
            
        }
            return null;
    }
    public GameObject RequestMelting()
    {
            

        for(int i =0 ; i < meltingList.Count ; i++)
        {
            if(!meltingList[i].activeInHierarchy)
            {
                return meltingList[i];
            }
            
        }
            return null;
    }



    public GameObject RequestEnemy()
    {
            

        for(int i =0 ; i < enemyList.Count ; i++)
        {
            if(!enemyList[i].activeInHierarchy)
            {
                return enemyList[i];
            }
            
        }
            return null;
    }
}
