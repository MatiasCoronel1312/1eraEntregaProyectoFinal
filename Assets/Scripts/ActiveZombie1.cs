using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZombie1 : MonoBehaviour// estos scripts son para agregar al enemy ya que al "matarlos" se desactiva el script de movimiento y al volver a activar el gameObject habia que activar el script
{
    [SerializeField] GameObject zombie;

    private void OnEnable()
    {
        zombie.GetComponent<Zombie1>().enabled = true;//activa el script Zombie 1
    }
}
