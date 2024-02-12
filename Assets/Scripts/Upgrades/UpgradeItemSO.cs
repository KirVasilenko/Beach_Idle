using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrades/Upgrade")]
public class UpgradeItemSO : ScriptableObject
{
    public Sprite icon; 
    public string description; 
    public int upgradeAmount; 

    public enum UpgradeType
    {
        AddClient,
        AddWaiters,
        IncreaseFoodCost,
        ReduceCookingTime
    }

    public UpgradeType upgradeType; 
}
