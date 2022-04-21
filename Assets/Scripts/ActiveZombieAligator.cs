using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZombieAligator : MonoBehaviour// estos scripts son para agregar al enemy ya que al "matarlos" se desactiva el script de movimiento y al volver a activar el gameObject habia que activar el script
{
    [SerializeField] GameObject zombie;

    private void OnEnable()
    {
        zombie.GetComponent<ZombieAligator>().enabled = true;//activa el script Zombie Aligator
    }
}
