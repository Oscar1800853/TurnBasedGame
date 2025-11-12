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

        agent.destination = destinationDummie.position;
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(1))
        {
            HandleClick();
            Units units = GetComponent<Units>();
            units.FinishMovement();
        }

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
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
        agent.nextPosition = transform.position;
    }
}
