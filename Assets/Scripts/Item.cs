using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int tier;  

    public GameObject itemModelPrefab;
    public Sprite icon;
    public GameObject productPrefab;

    [Header("Upgrade")]
    public UpgradeTable upgradeTable;  
    

    
    public float GetUpgradeCost()
{
    if (tier < upgradeTable.upgradeTiers.Length)
    {
        return upgradeTable.upgradeTiers[tier].cost;
    }

    return 0f;  
}


    public void UpgradeItem()
    {
        
       //click 
    }
}
