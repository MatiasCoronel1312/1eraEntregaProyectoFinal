using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Rotation")]
    private float cameraVerticalAngle;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;

    [Header("Moving")]

    [SerializeField] float runSpeed = 10f;
    private Vector3 velocidad;
    [SerializeField] float gravedad = -9.81f;
    [SerializeField] float altura = 10f;
    [SerializeField] float Speed = 5f;
    public float rotationSensibility = 30f;


    private CharacterController ccPlayer;

    //[Header("Animacion")]
   // [SerializeField] private Animator PlayerShooter;
    //private bool canShoot = true;
    //[SerializeField] public float shootCooldown = 1f;
   // [SerializeField] private float timeShoot = 0;

    private void Start()
    {

        ccPlayer = GetComponent<CharacterController>();
    }
    private void Update()
    {
        ccPlayer.Move(Vector3.down * 5f * Time.deltaTime);
        Look();
        //Fire();
       // Reload();
        //Point();
        Movimiento();
        JumpPlayer();
    }
    private void Moveplayer(Vector3 direccion)
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            ccPlayer.Move(runSpeed * Time.deltaTime * transform.TransformDirection(direccion));
        }else{
        ccPlayer.Move(Speed * Time.deltaTime * transform.TransformDirection(direccion));
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
            velocidad.y = Mathf.Sqrt(-altura * gravedad);
     
        }
        velocidad.y += gravedad * Time.deltaTime;
        ccPlayer.Move(velocidad * Time.deltaTime);

   

    }




    private void Look()
    {


        rotationinput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;

        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;


        cameraVerticalAngle += rotationinput.y;

        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -15, 15);

        transform.Rotate(Vector3.up * rotationinput.x);

        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);

    }

    // private void Fire()

    // {
    //     if ((Input.GetKeyDown(KeyCode.Mouse0)) && (canShoot))
    //     {
    //         PlayerShooter.SetBool("Fire", true);
    //         canShoot = false;
    //         timeShoot = 0;
    //     }
    //     else
    //     {
    //         timeShoot += Time.deltaTime;
    //     }
    //     if (timeShoot > shootCooldown)
    //     {
    //         canShoot = true;
    //     }

    //     if (Input.GetKeyUp(KeyCode.Mouse0))
    //     {
    //         PlayerShooter.SetBool("Fire", false);

    //     }
    // }



    // private void Reload()
    // {
    //     if (Input.GetKey(KeyCode.R))

    //     {
    //         PlayerShooter.SetBool("Reload", true);

    //     }

    //     if (Input.GetKeyUp(KeyCode.R))

    //     {
    //         PlayerShooter.SetBool("Reload", false);

    //     }
    // }
    // private void Point()
    // {
    //     if (Input.GetKey(KeyCode.Mouse1))

    //     {
    //         PlayerShooter.SetBool("Point", true);

    //     }

    //     if (Input.GetKeyUp(KeyCode.Mouse1))

    //     {
    //         PlayerShooter.SetBool("Point", false);

    //     }




    //     if (Input.GetKey(KeyCode.LeftShift))
    //     {
    //         PlayerShooter.SetBool("Run", true);
    //     }
    //     if (Input.GetKeyUp(KeyCode.LeftShift))
    //     {
    //         PlayerShooter.SetBool("Run", false);
    //     }
    // }
}