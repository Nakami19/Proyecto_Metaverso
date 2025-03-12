using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_movement_controller : MonoBehaviour
{
    //Listado de todos los fantasmas
    public GameObject[] ghosts;
    public float activationDelay = 1f;

 

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) // Verifica si el jugador entra en la zona de activación
        {
            StartCoroutine(ActivateGhostsWithDelay());
        }
    }

    IEnumerator ActivateGhostsWithDelay()
    {
        // Espera un tiempo antes de activar el movimiento de los fantasmas
        yield return new WaitForSeconds(activationDelay);

        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<ghost_movement>().StartMoving(); // Activa el movimiento de cada fantasma
        }
    }
}
