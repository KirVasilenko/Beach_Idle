using UnityEngine;
using System;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager instance;
    public static UpgradeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UpgradeManager>();

                if (instance == null)
                {
                    Debug.LogError("UpgradeManager instance not found in the scene.");
                }
            }
            return instance;
        }
    }

    public Action<int> OnAddClient;
    public Action<int> OnAddWaiter;
    public Action<float> OnIncreaseFoodCost;
    public Action<float> OnReduceCookingTime;

    public void ApplyAddClientUpgrade(int amount)
    {
        OnAddClient?.Invoke(amount);
    }

    public void ApplyAddWaiterUpgrade(int amount)
    {
        OnAddWaiter?.Invoke(amount);
    }

    public void ApplyIncreaseFoodCostUpgrade(float modifier)
    {
        OnIncreaseFoodCost?.Invoke(modifier);
    }

    public void ApplyReduceCookingTimeUpgrade(float reduction)
    {
        OnReduceCookingTime?.Invoke(reduction);
    }

    public void ApplyUpgrade(UpgradeItemSO upgrade)
    {
    
        switch (upgrade.upgradeType)
        {
            case UpgradeItemSO.UpgradeType.AddClient:
                ApplyAddClientUpgrade(upgrade.upgradeAmount);
                break;
            case UpgradeItemSO.UpgradeType.AddWaiters:
                ApplyAddWaiterUpgrade(upgrade.upgradeAmount);
                break;
            case UpgradeItemSO.UpgradeType.IncreaseFoodCost:
                ApplyIncreaseFoodCostUpgrade(upgrade.upgradeAmount);
                break;
            case UpgradeItemSO.UpgradeType.ReduceCookingTime:
                ApplyReduceCookingTimeUpgrade(upgrade.upgradeAmount);
                break;
            default:
                Debug.LogWarning("Unknown upgrade type: " + upgrade.upgradeType);
                break;
        }
    }
}
