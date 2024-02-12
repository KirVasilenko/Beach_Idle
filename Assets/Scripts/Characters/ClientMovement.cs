using UnityEngine;
using UnityEngine.AI;

public class ClientMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private TargetPoint targetPoint;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        MoveToAvailableTarget();
    }

    private void MoveToAvailableTarget()
    {
        Vector3 availableTargetPoint = TargetManager.Instance.GetAvailableTargetPoint();

        if (availableTargetPoint != Vector3.zero)
        {
            targetPoint = TargetManager.Instance.GetTargetPointByPosition(availableTargetPoint);

            if (targetPoint != null)
            {
                targetPoint.SetOccupied(true);
            }

            MoveTo(availableTargetPoint);
        }
        else
        {
            MoveToDestroyPoint();
        }
    }

    private void MoveTo(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
        animator.SetBool("IsWalk", true);
    }

    private void MoveToDestroyPoint()
    {
        GameObject destroyPoint = GameObject.FindGameObjectWithTag("Destroy");

        if (destroyPoint != null)
        {
            MoveTo(destroyPoint.transform.position);
        }
    }

    private void DestroyClient()
    {
        Destroy(gameObject); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            DestroyClient();
        }
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("IsWalk", false);
            TargetManager.Instance.NotifyClientApproach(targetPoint);
        }
        else
        {
            animator.SetBool("IsWalk", true);
        }
    }
}
