using UnityEngine;
using System.Collections.Generic;
using System;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }

    public List<TargetPoint> targetPoints = new List<TargetPoint>();
    public event Action<TargetPoint> OnClientApproach;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterTargetPoint(TargetPoint targetPoint)
    {
        if (!targetPoints.Contains(targetPoint))
        {
            targetPoints.Add(targetPoint);
        }
        else
        {
            Debug.LogWarning("Target point is already registered.");
        }
    }

    public void UnregisterTargetPoint(TargetPoint targetPoint)
    {
        targetPoints.Remove(targetPoint);
        ClientLoader clientIcon = targetPoint.GetComponentInChildren<ClientLoader>();
    
    }

    public bool IsTargetPointAvailable()
    {
        foreach (TargetPoint targetPoint in targetPoints)
        {
            if (!targetPoint.IsOccupied())
            {
                return true;
            }
        }
        return false;
    }

    public Vector3 GetAvailableTargetPoint()
    {
        foreach (TargetPoint targetPoint in targetPoints)
        {
            if (!targetPoint.IsOccupied())
            {
                return targetPoint.transform.position;
            }
        }
        return Vector3.zero;
    }

    public TargetPoint GetTargetPointByPosition(Vector3 position)
    {
        foreach (TargetPoint targetPoint in targetPoints)
        {
            if (targetPoint.transform.position == position)
            {
                return targetPoint;
            }
        }
        return null;
    }
    public void NotifyClientApproach(TargetPoint clientTargetPoint)
    {
        OnClientApproach?.Invoke(clientTargetPoint);
    }
}