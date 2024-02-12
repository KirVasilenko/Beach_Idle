using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WaiterMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private TargetPoint targetPoint;
    private bool isClientApproaching = false;
    private bool isWalking = false;
    private Loader loader;

    [SerializeField] private float baseOrderTime = 2f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        loader = GetComponentInChildren<Loader>();
    }

    private void MoveTo(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
        animator.SetBool("IsWalk", true);
        isWalking = true;
    }

    private void Update()
{
    if (isClientApproaching && targetPoint != null)
    {
        MoveTo(targetPoint.transform.position);
        isClientApproaching = false;
    }

    if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
    {
        isWalking = false;
        animator.SetBool("IsWalk", false);
    }

    if (targetPoint != null && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
    {
        navMeshAgent.isStopped = true;
        if (loader != null)
        {
            loader.ShowLoader();
            StartCoroutine(HideLoaderAfterDelay(baseOrderTime));
        }
        else
        {
            Debug.LogError("Loader component not found!");
        }
    }
    else if (!isClientApproaching)
    {
        navMeshAgent.isStopped = !isWalking;
    }
}

private IEnumerator HideLoaderAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    loader.HideLoader();

    // Направляем официанта к объекту с тегом "Lemonade"
    GameObject lemonadePoint = GameObject.FindGameObjectWithTag("Lemonade");
    if (lemonadePoint != null)
    {
        navMeshAgent.SetDestination(lemonadePoint.transform.position);
        isClientApproaching = false;
    }
    else
    {
        Debug.LogError("Lemonade point not found!");
    }
}


    private IEnumerator ShowLoaderCoroutine()
    {
        yield return new WaitForSeconds(0.5f); 
        loader.ShowLoader();
        yield return new WaitForSeconds(baseOrderTime); 
        loader.HideLoader();
        isClientApproaching = true; 
    }

    private void OnClientApproachHandler(TargetPoint clientTargetPoint)
    {
        targetPoint = clientTargetPoint;
        isClientApproaching = true;
    }

    private void OnEnable()
    {
        TargetManager.Instance.OnClientApproach += OnClientApproachHandler;
    }

    private void OnDisable()
    {
        TargetManager.Instance.OnClientApproach -= OnClientApproachHandler;
    }
}
