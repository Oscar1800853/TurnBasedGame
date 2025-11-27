using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    [Header("Movement Control")]
    [SerializeField] private float moveSpeed;
    Vector3 destination;
    Rigidbody rb;
    [SerializeField] Transform destinationDummie;
    NavMeshAgent agent;
    Animator animator;


    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent != null)
        {
            agent.ResetPath();
            agent.updatePosition = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("[ClickToMove] Botón derecho presionado");
            HandleClick();
            Units units = GetComponent<Units>();
            units.FinishMovement();
        }

        if (animator != null && agent != null)
            animator.SetFloat("ForwardMovement", agent.velocity.magnitude);
    }

    private void HandleClick()
    {
        //StartCoroutine(MoveToPosition(destination));
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            destinationDummie.position = hit.point;
            agent.destination = hit.point;
        }


    }
    
    private void OnAnimatorMove()
    {
        if (animator == null || agent == null) return;
        if (agent.updatePosition) return;
        
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
        agent.nextPosition = transform.position;
    }
}
