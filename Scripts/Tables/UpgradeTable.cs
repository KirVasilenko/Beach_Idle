using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Table", menuName = "Game/Upgrade Table")]
public class UpgradeTable : ScriptableObject
{
    public UpgradeTier[] upgradeTiers;
    public float BaseCookingTime;
    public int OpenCost;
    
}

[System.Serializable]
public class UpgradeTier
{
    public int ItemLevel; 
    public int FoodCost; 
    public int UpgradeCost; 
}
