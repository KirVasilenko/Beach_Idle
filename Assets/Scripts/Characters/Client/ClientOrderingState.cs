using UnityEngine;

public class ClientOrderingState : ClientState
{
    private Client _client;
    private ClientLoader _loader;
    private Sprite orderIcon; 

    public ClientOrderingState(Client client, ClientLoader loader, Sprite icon)
    {
        _client = client;
        _loader = loader;
        orderIcon = icon;
    }

    public override void EnterState()
    {
        _loader.ShowIcon(orderIcon); 
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        _loader.HideIcon(); 
    }
}
