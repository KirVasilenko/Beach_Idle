using UnityEngine;

public class ClientMovingState : ClientState
{
    private ClientLeavingState _leaveState;
    private Client _client;
    private TargetPoint _targetPoint;

    public ClientMovingState(Client client, ClientLeavingState leaveState)
    {
        _client = client;
        _leaveState = leaveState;
    }

    public override void EnterState()
{
    _client.anim.SetBool("IsWalk", true);
    

}


    public override void UpdateState()
    {
        if (_leaveState != null)
        {
        MoveToAvailableTarget();
        }
        
        if (_targetPoint != null && _client.navMeshAgent.remainingDistance <= _client.navMeshAgent.stoppingDistance)
        {
            _client.navMeshAgent.isStopped = true;
            _client.anim.SetBool("IsWalk", false);
            TargetManager.Instance.NotifyClientApproach(_targetPoint);
        }
        else
        {
            _client.anim.SetBool("IsWalk", true);
        }
    }

    public override void ExitState()
    {
        
    }

    private void MoveToAvailableTarget()
    {
        Vector3 availableTargetPoint = TargetManager.Instance.GetAvailableTargetPoint();

        if (availableTargetPoint != Vector3.zero)
        {
            _targetPoint = TargetManager.Instance.GetTargetPointByPosition(availableTargetPoint);

            if (_targetPoint != null)
            {
                _targetPoint.SetOccupied(true);
                MoveTo(availableTargetPoint);
            }
            else
            {
                Debug.LogWarning("Target point not found.");
                _leaveState.EnterState();
            }
        }
        else
        {
            Debug.LogWarning("Available target point not found.");
            _leaveState.MoveToDestroyPoint();
        }
    }

    public void MoveTo(Vector3 destination)
    {
        _client.navMeshAgent.SetDestination(destination);
        _client.anim.SetBool("IsWalk", true);
    }
}