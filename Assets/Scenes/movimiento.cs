using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public float raycastDistance = 1.5f; //Distancia a un objeto enfrente
    public float groundCheckDistance = 0.3f; //Distancia a la que detecta el suelo
    public float enemyJumpMultiplier = 1.5f;

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
            Debug.Log("Saltando");
            if (hit.collider.CompareTag("Cubo") && !isJumping)
            {
                Debug.Log("Saltando Parte 2");
                Jump();
            }
            else if (hit.collider.CompareTag("Enemigo") && !isJumping) // Detección de enemigo
            {
                Jump(enemyJumpMultiplier); // Salta más alto si es un enemigo
            }
        }

        // Verificar si está cayendo
        CheckIfFalling();
    }

    void Jump(float multiplier = 1f)
    {
        isJumping = true;
        animator.SetBool("EstaSaltando", true);
        animator.SetBool("EstaCorriendo", false);
        //Reiniciar velocidad
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.AddForce(Vector3.up * jumpForce * multiplier, ForceMode.Impulse);
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
    //public float moveSpeed = 2f;
    //public float jumpForce = 5f;
    //public float enemyJumpMultiplier = 1.5f;
    //public float groundCheckDistance = 0.3f;

    //private bool isJumping = false;
    //private bool isGrounded = true; // Para evitar saltos continuos
    //private Rigidbody rb;
    //private Animator animator;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    animator = GetComponent<Animator>();
    //    animator.SetBool("EstaCorriendo", true);
    //}

    //void Update()
    //{
    //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    //    CheckIfFalling();
    //}

    //void OnTriggerEnter(Collider other) // Se activa cuando entra en un trigger
    //{
    //    if (isGrounded && !isJumping) // Solo salta si está en el suelo y no está ya en el aire
    //    {
    //        if (other.CompareTag("Cubo"))
    //        {
    //            Jump();
    //        }
    //        else if (other.CompareTag("Enemigo"))
    //        {
    //            Jump(enemyJumpMultiplier);
    //        }
    //    }
    //}

    //void Jump(float multiplier = 1f)
    //{
    //    isJumping = true;
    //    isGrounded = false;
    //    animator.SetBool("EstaSaltando", true);
    //    animator.SetBool("EstaCorriendo", false);

    //    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    //    rb.AddForce(Vector3.up * jumpForce * multiplier, ForceMode.Impulse);
    //}

    //void CheckIfFalling()
    //{
    //    float characterDepth = GetComponent<Collider>().bounds.extents.z;

    //    Vector3 frontCheckOrigin = transform.position + transform.forward * characterDepth + Vector3.up * 0.1f;
    //    Vector3 backCheckOrigin = transform.position - transform.forward * characterDepth + Vector3.up * 0.1f;

    //    Debug.DrawRay(frontCheckOrigin, Vector3.down * groundCheckDistance, Color.green);
    //    Debug.DrawRay(backCheckOrigin, Vector3.down * groundCheckDistance, Color.green);

    //    bool isGroundedFront = Physics.Raycast(frontCheckOrigin, Vector3.down, groundCheckDistance);
    //    bool isGroundedBack = Physics.Raycast(backCheckOrigin, Vector3.down, groundCheckDistance);

    //    isGrounded = isGroundedFront || isGroundedBack;

    //    if (!isGrounded)
    //    {
    //        animator.SetBool("EstaSaltando", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("EstaSaltando", false);
    //        animator.SetBool("EstaCorriendo", true);
    //        Land();
    //    }
    //}

    //void Land()
    //{
    //    isJumping = false;
    //    isGrounded = true;
    //}
}

