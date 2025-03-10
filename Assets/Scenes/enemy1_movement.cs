using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_movement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float raycastDistance = 1.2f; // Distancia para detectar cubos
    public float rotationSpeed = 2f; // Velocidad de giro

    private bool isTurning = false; // Para evitar múltiples giros a la vez


    void Update()
    {
        if (!isTurning)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            CheckForObstacle();
        }
    }

    void CheckForObstacle()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * 0.5f; // Elevar un poco para evitar colisiones erróneas
        Debug.DrawRay(rayOrigin, transform.forward * raycastDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Cubo") && !isTurning)
            {
                StartCoroutine(TurnAround());
            }
        }
    }

    IEnumerator TurnAround()
    {
        isTurning = true;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 180, 0); // Girar 180° en el eje Y

        float elapsedTime = 0f;
        float turnDuration = 0.5f; // Ajusta este valor para hacer el giro más rápido o más lento

        while (elapsedTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / turnDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // Asegurar que la rotación final sea exacta
        isTurning = false;
    }

    //public float moveSpeed = 2f; // Velocidad de movimiento
    //public float rotationSpeed = 2f; // Velocidad de giro

    //private bool isTurning = false; // Para evitar múltiples giros a la vez

    //void Update()
    //{
    //    if (!isTurning)
    //    {
    //        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    //    }
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Regreso") && !isTurning)
    //    {
    //        StartCoroutine(TurnAround());
    //    }
    //}

    //IEnumerator TurnAround()
    //{
    //    isTurning = true;

    //    Quaternion startRotation = transform.rotation;
    //    Quaternion targetRotation = startRotation * Quaternion.Euler(0, 180, 0); // Girar 180° en el eje Y

    //    float elapsedTime = 0f;
    //    float turnDuration = 0.5f; // Ajusta este valor para hacer el giro más rápido o más lento

    //    while (elapsedTime < turnDuration)
    //    {
    //        transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / turnDuration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    transform.rotation = targetRotation; // Asegurar que la rotación final sea exacta
    //    isTurning = false;
    //}
}
