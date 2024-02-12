using UnityEngine;
using System;

public class TargetPoint : MonoBehaviour
{
    private bool isOccupied = false;
    private bool orderAccepted = false;
    public event Action<TargetPoint> OnOccupied;
    public event Action<TargetPoint> OnClientApproach;
    private bool loaderShown = false;
   

    private void Start()
    {
        isOccupied = false;

        orderAccepted = false;
    }

   

     public void ResetLoaderShown()
    {
    loaderShown = false;
    }

     public bool IsLoaderShown()
    { 
    return loaderShown;
    }
    
    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
        if (isOccupied)
        {
            OnOccupied?.Invoke(this);
            OnClientApproach?.Invoke(this); 
        }
    }

    public void AcceptOrder()
    {
        orderAccepted = true;
    }
}
