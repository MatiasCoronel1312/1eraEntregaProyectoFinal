using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCollision : MonoBehaviour
{

    public event Action OnDeath;// creo un event para desactivar el script de movimiento del enemigo 
    [SerializeField] public float timerAnimation = 2f;
    [SerializeField] private int LifeEnemy = 3;//los impactos de  pistola, hay que dipara tres veces en el pecho o en los brazos(en la cabeza solo una)
    [SerializeField] private int LifeArmL = 3;
    [SerializeField] private int LifeArmR = 3;

    [SerializeField] private Animator Zombie;
    [SerializeField] GameObject head;//desactivar la cabeza 
    [SerializeField] GameObject neck;//y generar la sangre en el cuello
    [SerializeField] GameObject body;
    [SerializeField] GameObject player;
    [SerializeField] GameObject armRight;// para desactivar las manos y los brazos
    [SerializeField] GameObject foreArmRight;
    [SerializeField] GameObject armLeft;
    [SerializeField] GameObject foreArmLeft;
    

    private void Awake() {
        player = GameObject.Find("Player");
        
    }

    private void OnEnable() {//al activar al enemigo volver a resetear todo su cuerpo

        LifeEnemy=3;
        LifeArmL = 3;
        LifeArmR = 3;
        transform.localScale = new Vector3(1f,1f,1f);
        foreArmRight.SetActive(true);
        armRight.SetActive(true);
        foreArmLeft.SetActive(true);
        armLeft.SetActive(true);
        head.SetActive(true);

    }
    // segun donde se dispara y con que arma se puede matar al enemigo con una o 3 balas
    public void BulletImpactGunHead(){
        BulletImpactHead();        
        StartCoroutine(IsDeath()); 
    }
    public void BulletImpactShotgunHead(){
        BulletImpactHead();
        head.SetActive(false);
        StartCoroutine(IsDeath()); 
    }
    public void BulletImpactGun(){
        BulletImpact();
        LifeEnemy--;
        if(LifeEnemy<1){
            StartCoroutine(IsDeath());
        }
    }
    public void BulletImpactShotgun(){
        BulletImpact();
        StartCoroutine(IsDeath());
    }
    public void BulletImpactArmRGun(){
        BulletImpactArmRight();
        LifeArmR--;
        if(LifeArmR<1){
            foreArmRight.SetActive(false);
            armRight.SetActive(false);
        }
    }
    public void BulletImpactArmLGun(){
        BulletImpactArmLeft();
        LifeArmL--;
        if(LifeArmL<1){
            foreArmLeft.SetActive(false);
            armLeft.SetActive(false);
        
        }
    }
    public void BulletImpactArmRShotgun(){
            BulletImpactArmRight();
            foreArmRight.SetActive(false);
            armRight.SetActive(false);
    }
    public void BulletImpactArmLShotgun(){
            BulletImpactArmLeft();
            foreArmLeft.SetActive(false);
            armLeft.SetActive(false);       
    }

    public void BulletImpact(){
            GameObject b = GameManager.instancePlayer.RequestBlood();// y se llama ala sangre del pool del single
            b.SetActive(true);
            b.transform.position = body.transform.position;
            b.transform.rotation = player.transform.rotation;
            
    }

    public void BulletImpactArmRight()
    {
            GameObject b = GameManager.instancePlayer.RequestBlood();
            b.SetActive(true);
            b.transform.position = foreArmRight.transform.position;
            b.transform.rotation = foreArmRight.transform.rotation;
    }
    public void BulletImpactArmLeft()
    {
            GameObject b = GameManager.instancePlayer.RequestBlood();
            b.SetActive(true);
            b.transform.position = foreArmLeft.transform.position;
            b.transform.rotation = foreArmLeft.transform.rotation;
    }

    public void BulletImpactHead(){
            GameObject c = GameManager.instancePlayer.RequestBlood();
            c.SetActive(true);
            c.transform.position = neck.transform.position; 
            c.transform.rotation = player.transform.rotation;           
    }
    
    
    // esto es para la colision del cuchillo

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Knife"))
        {
            GameObject b = GameManager.instancePlayer.RequestBlood();
            b.SetActive(true);
            b.transform.position = neck.transform.position;
            b.transform.rotation = player.transform.rotation;            
            StartCoroutine(IsDeath());
            
        }
    }

    IEnumerator IsDeath() {// y la corrutina de la muerte del enemy
        OnDeath?.Invoke();
        Zombie.SetBool("IsDeath", true);// animacion de muerte
        yield return new WaitForSeconds(timerAnimation*0.3f);
        GameObject b = GameManager.instancePlayer.RequestMelting();// se instancia unas particulas verdes
        b.SetActive(true);
        b.transform.position = transform.position;        
        yield return new WaitForSeconds(timerAnimation*0.2f);// y se le va restando al eje de Z(porque esta acostado)
        transform.localScale -= new Vector3(0f,0.2f,0f);//para que parezca que de va derritiendo
        yield return new WaitForSeconds(timerAnimation*0.2f);
        transform.localScale -= new Vector3(0f,0.2f,0f);
        yield return new WaitForSeconds(timerAnimation*0.6f);
        gameObject.SetActive(false);// y se desactiva
        
    }

    
}
