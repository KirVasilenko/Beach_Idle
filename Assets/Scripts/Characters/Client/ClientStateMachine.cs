using UnityEngine;

public class ClientStateMachine
{
    public ClientState CurrentState { get; set; }

    public void Initialize(ClientState startState)
    {
        CurrentState = startState;
        CurrentState.EnterState();
    }


    public void ChangeState(ClientState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }
}
