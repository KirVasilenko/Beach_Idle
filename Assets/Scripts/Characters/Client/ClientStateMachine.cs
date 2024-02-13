using UnityEngine;

public class ClientStateMachine
{
    public ClientState CurrentState { get; set; }

    public ClientStateMachine(ClientState initialState)
    {
        CurrentState = initialState;
        CurrentState.SetStateMachine(this);
        CurrentState.EnterState();
    }

    public void UpdateState()
    {
        CurrentState.UpdateState();
    }

    public void EnterState()
    {
        CurrentState.EnterState();
    }
}
