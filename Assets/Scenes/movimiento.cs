using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class movimiento : MonoBehaviour
{
    public float moveSpeed = 2f; //Velocidad a la que corre
    public float jumpForce = 5f; //fuerza de salto
    public float raycastDistance = 1.5f; //Distancia a un objeto enfrente
    public float groundCheckDistance = 0.3f; //Distancia a la que detecta el suelo
    public float enemyJumpMultiplier = 1.5f; //Salto mas alto en caso de enemigo
    public float stepBackDistance = 1f; // Distancia que se moverá hacia atrás
    public float stepBackSpeed = 1f; // Velocidad al retroceder
    public CinemachineVirtualCamera virtualCamera;


    private bool isJumping = false;
    private Rigidbody rb;
    private Animator animator;
    private AudioSource audioSource;
    public bool isPaused = false;
    private CinemachineFramingTransposer transposer;

    void Start()
    {
        Application.targetFrameRate = 60;


        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("EstaCorriendo", true);
        audioSource = GetComponent<AudioSource>();
        if (virtualCamera != null)
        {
            var framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            if (framingTransposer != null)
            {
                transposer = framingTransposer;
            }
        } 
    }

    void Update()
    {
        if (!isPaused )
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

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

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void CheckIfFalling()
    {

        //Verifica si esta cayendo mediante raycast en los bordes del personaje
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
            Land();
        }
    }

    void Land()
    {
        isJumping = false;
        animator.SetBool("EstaSaltando", false);
        if (!isPaused && animator.GetBool("EstaCaminando") == false) // Solo volver a correr si no está en pausa y no esta caminando
        {
            animator.SetBool("EstaCorriendo", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Momento donde entra al bosque oscuro
        if (other.CompareTag("TriggerZone"))
        {
            StartCoroutine(StopAndResume());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Momento donde empiezan los fantasmas
        if (other.CompareTag("TriggerZone2"))
        {
            StartCoroutine(ChangeCamara());
        }
    }

    IEnumerator ChangeCamara() {
        if (transposer != null)
        {
            //Centrar la camara
            float originalOffsetZ = transposer.m_TrackedObjectOffset.z; 
            float targetOffsetZ = 0;

            float elapsedTime = 0f;
            float duration = 1f;  // Duración de la transición

            while (elapsedTime < duration)
            {
                transposer.m_TrackedObjectOffset.z = Mathf.Lerp(originalOffsetZ, targetOffsetZ, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transposer.m_TrackedObjectOffset.z = targetOffsetZ;
        }
    }

    IEnumerator StopAndResume()
    {
        //Empieza a caminar
        moveSpeed = 1f;
        animator.SetBool("EstaCorriendo", false);
        animator.SetBool("EstaSaltando", false);
        animator.SetBool("EstaCaminando", true);
        yield return new WaitForSeconds(3f);
        //Se detiene
        isPaused = true;
        animator.SetBool("EstaCaminando", false);
        yield return new WaitForSeconds(1f);
        //Empieza a caminar hacia atras
        animator.SetBool("EstaCaminando", true);
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition - transform.forward * stepBackDistance;

        while (elapsedTime < stepBackDistance / stepBackSpeed)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime * stepBackSpeed) / stepBackDistance);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //Para de caminar y se detiene un poco
        transform.position = targetPosition;
        animator.SetBool("EstaCaminando", false);

        yield return new WaitForSeconds(1f);
        //Vuelve a correr
        animator.SetBool("EstaCorriendo", true);
        isPaused = false;
        moveSpeed = 2f;
    }
}

