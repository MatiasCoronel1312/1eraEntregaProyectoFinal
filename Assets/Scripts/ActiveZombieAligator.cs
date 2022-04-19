using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZombieAligator : MonoBehaviour
{
    [SerializeField] GameObject zombie;

    private void OnEnable() {
        zombie.GetComponent<ZombieAligator>().enabled=true;//activa el script Zombie Aligator
    }
}
