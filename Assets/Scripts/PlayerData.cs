using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Player Data", menuName ="Create Player Data")]

public class PlayerData : ScriptableObject
{
    

    [Header("Rotation")]// variables para la rotacion de la camara    

    [SerializeField] public float rotationSensibility = 60f;
    [SerializeField] public float angleMax = -25f;
    [SerializeField] public float angleMin = 25f;

    [Header("Moving")]

    [SerializeField] public float runSpeed = 10f;
    
    [SerializeField] public float gravedad = -9.81f;
    [SerializeField] public float altura = -10f;
    [SerializeField] public float Speed = 5f;

    
}
