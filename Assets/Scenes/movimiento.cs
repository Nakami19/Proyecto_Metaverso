using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    //public float velocidadMovimiento = 5f; // Velocidad de movimiento
    //public float distanciaDeteccion = 3f; // Distancia a la que detecta el cubo
    //public float fuerzaSalto = 5f; // Fuerza del salto
    //public GameObject cubo; // Referencia al cubo
    //private Animator animator;
    //private bool estaSaltando = false;

    // Start is called before the first frame update
    //void Start()
    //{
    //    // Obtén el componente Animator del objeto
    //    animator = GetComponent<Animator>();

    //    // Inicia la corrutina para controlar el comportamiento
    //    //StartCoroutine(ControlarMovimiento());
    //    // Comienza a correr indefinidamente
    //    StartCoroutine(Correr());
    //}
    // Corrutina para controlar el movimiento
    //IEnumerator ControlarMovimiento()
    //{
    //    while (estaActivo)
    //    {
    //        // Primero, el objeto está quieto
    //        animator.SetBool("EstaCorriendo", false);
    //        yield return new WaitForSeconds(tiempoQuietoInicial);

    //        // Luego, el objeto comienza a correr y moverse indefinidamente
    //        animator.SetBool("EstaCorriendo", true);

    //        // Mueve el objeto hacia adelante indefinidamente
    //        while (true) // Bucle infinito
    //        {
    //            Vector3 movimiento = transform.forward; // Mueve el objeto hacia adelante
    //            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);
    //            yield return null; // Espera al siguiente frame
    //        }
    //    }
    //    //    while (estaActivo)
    //    //    {
    //    //        // Primero, el objeto está quieto
    //    //        animator.SetBool("EstaCorriendo", false);
    //    //        yield return new WaitForSeconds(tiempoQuietoInicial);

    //    //        // Luego, el objeto comienza a correr y moverse
    //    //        animator.SetBool("EstaCorriendo", true);
    //    //        float tiempoInicio = Time.time;

    //    //        // Mueve el objeto mientras esté corriendo
    //    //        //while (Time.time - tiempoInicio < tiempoCorriendo)
    //    //        {
    //    //            Vector3 movimiento = transform.forward; // Mueve el objeto hacia adelante
    //    //            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);
    //    //            yield return null; // Espera al siguiente frame
    //    //        }

    //    //        //// Finalmente, el objeto regresa a estar quieto
    //    //        //animator.SetBool("EstaCorriendo", false);
    //    //        //yield return new WaitForSeconds(tiempoQuietoInicial);
    //    //    }
    //}

    //IEnumerator Correr()
    //{
    //    // Activa la animación de correr
    //    animator.SetBool("EstaCorriendo", true);

    //    while (true) // Bucle infinito para correr indefinidamente
    //    {
    //        // Mueve el objeto hacia adelante
    //        Vector3 movimiento = transform.forward;
    //        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);

    //        // Verifica si está cerca del cubo y no está saltando
    //        if (!estaSaltando && Vector3.Distance(transform.position, cubo.transform.position) <= distanciaDeteccion)
    //        {
    //            // Comienza el salto
    //            StartCoroutine(Saltar());
    //        }

    //        yield return null; // Espera al siguiente frame
    //    }
    //}
    //IEnumerator Saltar()
    //{
    //    // Activa la animación de salto
    //    estaSaltando = true;
    //    animator.SetBool("EstaSaltando", true);
    //    animator.SetBool("EstaCorriendo", false); // Desactiva la animación de correr

    //    // Aplica fuerza hacia arriba para simular el salto
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        Vector3 direccionSalto = (Vector3.up + transform.forward).normalized;
    //        rb.AddForce(direccionSalto * fuerzaSalto, ForceMode.Impulse);
    //    }

    //    // Espera a que termine la animación de salto (ajusta el tiempo según tu animación)
    //    yield return new WaitForSeconds(1.5f); // Ajusta este valor según la duración de tu animación

    //    // Desactiva la animación de salto y vuelve a correr
    //    animator.SetBool("EstaSaltando", false);
    //    animator.SetBool("EstaCorriendo", true);
    //    estaSaltando = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    // Calcula la distancia entre este objeto y el cubo
    //    float distanciaAlCubo = Vector3.Distance(transform.position, cubo.transform.position);

    //    // Si está cerca del cubo y no está saltando, comienza el salto
    //    if (distanciaAlCubo <= distanciaDeteccion && !estaSaltando)
    //    {
    //        StartCoroutine(Saltar());
    //    }
    // Obtén la entrada del teclado (por ejemplo, las flechas o WASD)
    //float movimientoHorizontal = Input.GetAxis("Horizontal"); // Movimiento lateral
    //float movimientoVertical = Input.GetAxis("Vertical"); // Movimiento frontal

    //// Crea un vector de movimiento
    //Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

    //// Si hay movimiento, reproduce la animación de correr
    //if (movimiento.magnitude > 0)
    //{
    //    animator.SetBool("EstaCorriendo", true);

    //    // Normaliza el vector para que el movimiento sea uniforme
    //    movimiento.Normalize();

    //    // Mueve el objeto
    //    transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);

    //    // Opcional: Rota el objeto hacia la dirección del movimiento
    //    if (movimiento != Vector3.zero)
    //    {
    //        Quaternion toRotation = Quaternion.LookRotation(movimiento, Vector3.up);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
    //    }
    //}
    //else
    //{
    //    // Si no hay movimiento, detén la animación de correr
    //    animator.SetBool("EstaCorriendo", false);
    //}
    //}
    //public float velocidadMovimiento = 5f; // Velocidad de movimiento
    //public float distanciaDeteccion = 3f; // Distancia a la que detecta el cubo
    //public float fuerzaSalto = 5f; // Fuerza del salto
    //public GameObject cubo; // Referencia al cubo
    //private Animator animator;
    //private bool estaSaltando = false;
    //private Rigidbody rb;
    //void Start()
    //{
    //    // Obtén el componente Animator y Rigidbody del objeto
    //    animator = GetComponent<Animator>();
    //    rb = GetComponent<Rigidbody>();

    //    // Comienza a correr indefinidamente
    //    StartCoroutine(Correr());
    //}

    //IEnumerator Correr()
    //{
    //    // Activa la animación de correr
    //    animator.SetBool("EstaCorriendo", true);

    //    while (true) // Bucle infinito para correr indefinidamente
    //    {
    //        // Mueve el objeto hacia adelante
    //        Vector3 movimiento = transform.forward;
    //        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);

    //        // Verifica si está cerca del cubo y no está saltando
    //        if (!estaSaltando && Vector3.Distance(transform.position, cubo.transform.position) <= distanciaDeteccion)
    //        {
    //            // Comienza el salto
    //            StartCoroutine(Saltar());
    //        }

    //        yield return null; // Espera al siguiente frame
    //    }
    //}

    //IEnumerator Saltar()
    //{
    //    // Activa la animación de salto
    //    estaSaltando = true;
    //    animator.SetBool("EstaSaltando", true);
    //    animator.SetBool("EstaCorriendo", false); // Desactiva la animación de correr

    //    // Aplica fuerza hacia arriba y adelante para simular el salto
    //    if (rb != null)
    //    {
    //        Vector3 direccionSalto = (Vector3.up + transform.forward).normalized;
    //        rb.AddForce(direccionSalto * fuerzaSalto, ForceMode.Impulse);
    //    }

    //    // Espera a que termine la animación de salto (ajusta el tiempo según tu animación)
    //    yield return new WaitForSeconds(1.5f); // Ajusta este valor según la duración de tu animación

    //    // Desactiva la animación de salto y vuelve a correr
    //    animator.SetBool("EstaSaltando", false);
    //    animator.SetBool("EstaCorriendo", true);
    //    estaSaltando = false;
    //}
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public float raycastDistance = 1.5f;
    public float groundCheckDistance = 0.3f; // Asegura que detecta el suelo

    private bool isJumping = false;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("EstaCorriendo", true);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Verificar si hay un cubo adelante con un Raycast
        Vector3 rayOrigin = transform.position + Vector3.up * 0.5f; // Se eleva un poco para evitar colisiones erróneas
        Debug.DrawRay(rayOrigin, transform.forward * raycastDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Cubo") && !isJumping)
            {
                Jump();
            }
        }

        // Verificar si está cayendo
        CheckIfFalling();
    }

    void Jump()
    {
        isJumping = true;
        animator.SetBool("EstaSaltando", true);
        animator.SetBool("EstaCorriendo", false);

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CheckIfFalling()
    {
        // Lanza un Raycast desde el centro del personaje hacia abajo
        //Vector3 groundCheckOrigin = transform.position + Vector3.up * 0.1f;
        //Debug.DrawRay(groundCheckOrigin, Vector3.down * groundCheckDistance, Color.green);

        //bool isGrounded = Physics.Raycast(groundCheckOrigin, Vector3.down, groundCheckDistance);
        float characterDepth = GetComponent<Collider>().bounds.extents.z;

        Vector3 frontCheckOrigin = transform.position + transform.forward * characterDepth + Vector3.up * 0.1f;
        Vector3 backCheckOrigin = transform.position - transform.forward * characterDepth + Vector3.up * 0.1f;

        Debug.DrawRay(frontCheckOrigin, Vector3.down * groundCheckDistance, Color.green);
        Debug.DrawRay(backCheckOrigin, Vector3.down * groundCheckDistance, Color.green);

        bool isGroundedFront = Physics.Raycast(frontCheckOrigin, Vector3.down, groundCheckDistance);
        bool isGroundedBack = Physics.Raycast(backCheckOrigin, Vector3.down, groundCheckDistance);

        bool isGrounded = isGroundedFront || isGroundedBack;

        if (!isGrounded)
        {
            animator.SetBool("EstaSaltando", true);
        }
        else 
        {
            animator.SetBool("EstaSaltando", false);
            animator.SetBool("EstaCorriendo", true);
            Land();
        }
    }

    void Land()
    {
        isJumping = false;
        //animator.SetBool("EstaSaltando", false);
        //animator.SetBool("EstaCorriendo", true);
    }
}

