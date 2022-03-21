using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] protected PlayerData player;

    [Header("References")]
    public Camera playerCamera;

    [Header("Rotation")]// variables para la rotacion de la camara
    private float cameraVerticalAngle;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
 

    [Header("Moving")]
    private Vector3 velocidad;
    private CharacterController ccPlayer;
        
    [Header("Animacion")]
    [SerializeField] private Animator PlayerShooter;
    [SerializeField] private Animator PlayerKnife;
    [SerializeField] private Animator PlayerShotgun;


    private void Start()
    {
        ccPlayer = GetComponent<CharacterController>();

        transform.position = FindObjectOfType<CheckpointsManager>().GetCheckPoint(GameManager.instancePlayer.lastSP).position;
        
    }
    private void Update()
    {
        ccPlayer.Move(Vector3.down * 5f * Time.deltaTime);
        Look();
        Movimiento();
        JumpPlayer();
    }
    private void Moveplayer(Vector3 direccion)
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            ccPlayer.Move(player.runSpeed * Time.deltaTime * transform.TransformDirection(direccion));//si se mueve apretando tambien el shift va a correr, o sea multiplica la velocidad
        }else{
        ccPlayer.Move(player.Speed * Time.deltaTime * transform.TransformDirection(direccion));
        }
    }
    private void Movimiento()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Moveplayer(Vector3.forward);
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            Moveplayer(Vector3.left);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Moveplayer(Vector3.back);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Moveplayer(Vector3.right);    
        }
        
    }


    private void JumpPlayer()
    {

        if (Input.GetKeyDown(KeyCode.Space) && ccPlayer.isGrounded)
        {
            velocidad.y = Mathf.Sqrt(player.altura * player.gravedad);
     
        }
        velocidad.y += player.gravedad * Time.deltaTime;
        ccPlayer.Move(velocidad * Time.deltaTime);   

    }
    private void Look()
    {

        //mueve la camara con el mouse en Y y X
        rotationinput.x = Input.GetAxis("Mouse X") * player.rotationSensibility * Time.deltaTime;

        rotationinput.y = Input.GetAxis("Mouse Y") * player.rotationSensibility * Time.deltaTime;


        cameraVerticalAngle += rotationinput.y;

        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, player.angleMax, player.angleMin);//este es el angulo maximo

        transform.Rotate(Vector3.up * rotationinput.x);

        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);

    }





}
