using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZombie1 : MonoBehaviour
{
    [SerializeField] GameObject zombie;

    private void OnEnable() {
        zombie.GetComponent<Zombie1>().enabled=true;//activa el script Zombie 1
    }
}
