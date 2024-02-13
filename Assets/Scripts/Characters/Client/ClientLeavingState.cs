using UnityEngine;

public class ClientLeavingState : ClientState
{
    private Client _client;
    private ClientMovingState _movingState;

    public ClientLeavingState(Client client, ClientMovingState movingState)
    {
        _client = client;
        _movingState = movingState;
    }


    public override void EnterState()
    {
        MoveToDestroyPoint();
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public void MoveToDestroyPoint()
    {
        GameObject destroyPoint = GameObject.FindGameObjectWithTag("Destroy");

        if (destroyPoint != null)
        {
            _movingState.MoveTo(destroyPoint.transform.position);
        }
    }    
}