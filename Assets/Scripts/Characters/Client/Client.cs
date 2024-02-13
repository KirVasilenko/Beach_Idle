using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour 
{
    public NavMeshAgent navMeshAgent;
    public Animator anim;
    private ClientMovingState _moving;
    private ClientStateMachine _SM;
    private ClientLeavingState _leaving;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        _moving = new ClientMovingState(this, _leaving); 
        _leaving = new ClientLeavingState(this, _moving); 
        _SM = new ClientStateMachine(); 
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
        _SM.CurrentState.UpdateState();
        _SM.ChangeState(_moving);   
    }
}
