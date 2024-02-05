using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Table", menuName = "Game/Upgrade Table")]
public class UpgradeTable : ScriptableObject
{
    public UpgradeTier[] upgradeTiers;
}

[System.Serializable]
public class UpgradeTier
{
    public int level;
    public float cost;
    public float upgradeValue;
}
