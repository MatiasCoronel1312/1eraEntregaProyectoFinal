using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Enemy Data", menuName ="Create Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float speedEnemy;
    [SerializeField] public float distancePlayer;
    [SerializeField] public float attackPlayer;
    [SerializeField] public float bitePlayer;

}
