using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_movement : MonoBehaviour
{

    public float moveSpeed = 1f; //Velocidad movimiento
    public float detectionDistance = 2f; // Distancia para detectar personaje
    public float attackMoveDistance = 1f; // Distancia extra que avanza al atacar
    private Animator animator; 
    public GameObject player; // Referencia al personaje principal

    private bool isAttacking = false; // Control para evitar múltiples ataques
    private bool isActivated = false; //Determina si fantasma se mueve
    private Vector3 attackTargetPosition; // Posición final del ataque

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && isActivated)
        {
            // Movimiento normal del fantasma
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (isActivated)
        {
            DetectEnemy();
        }
    }

    public void StartMoving()
    {
        isActivated = true;
        moveSpeed = 1f;
    }

    void DetectEnemy()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * 0.5f; // Se eleva un poco para evitar colisiones erróneas
        Debug.DrawRay(rayOrigin, transform.forward * detectionDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, detectionDistance))
        {   //Detecta al personaje principal
            if (hit.collider.CompareTag("Player") && !isAttacking)
            {
                StartCoroutine(AttackSequence(hit.collider.gameObject));
            }
        }
    }

    IEnumerator AttackSequence(GameObject enemy)
    {
        isAttacking = true; // Evitar múltiples ataques
        animator.SetTrigger("Attack"); // Cambiar a animación de ataque
        Animator playerAnimator = player.GetComponent<Animator>();
        movimiento playerMovement = enemy.GetComponent<movimiento>();
        
        //Para movimiento de personaje
        playerMovement.isPaused = true;
        playerMovement.moveSpeed = 0f;

        playerAnimator.SetBool("EstaCorriendo", false);
        playerAnimator.SetBool("EstaSaltando", false);

        // Avanza una distancia adicional antes de detenerse
        attackTargetPosition = transform.position + transform.forward * attackMoveDistance;
        float elapsedTime = 0f;
        float attackDuration = 0.5f; // Tiempo que tarda en avanzar 

        while (elapsedTime < attackDuration)
        {
            transform.position = Vector3.Lerp(transform.position, attackTargetPosition, (elapsedTime / attackDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = attackTargetPosition; 
        moveSpeed = 0f; // Detener movimiento

        // Esperar a que termine la animación de ataque
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Activar la animación de "perder" en el personaje principal
            
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Lose");
            }


        //Moverse un poco hacia atras luego del ataque
        Vector3 retreatPosition = transform.position - transform.forward * attackMoveDistance;

        elapsedTime = 0f;
        float retreatDuration = 0.5f;

        while (elapsedTime < retreatDuration)
        {
            transform.position = Vector3.Lerp(transform.position, retreatPosition, (elapsedTime / retreatDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = retreatPosition;


    }

}
