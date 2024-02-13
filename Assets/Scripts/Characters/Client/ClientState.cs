using System;
using UnityEngine;

public abstract class ClientState
{
    protected ClientStateMachine stateMachine;

    public virtual void EnterState() 
    {

    }
    public virtual void UpdateState()
     {

     }
    public virtual void ExitState()
     {
        
     }

    public void SetStateMachine(ClientStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


}
