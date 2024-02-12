using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeTemplate : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI descriptionText; 
    public TextMeshProUGUI upgradeAmountText; 
    public Button upgradeButton; 
    public UpgradeItemSO upgradeItem;
    public UpgradeManager upgradeManager;

    
    public void SetUpgrade(UpgradeItemSO upgrade)
    {
        upgradeItem = upgrade;
        

        
        iconImage.sprite = upgrade.icon;

        
        descriptionText.text = upgrade.description;

        
        upgradeAmountText.text = upgrade.upgradeAmount.ToString();

        
    }
    public void ApplyUpgrade()
    
    {
    UpgradeManager.Instance.ApplyUpgrade(upgradeItem);
    }

    


}
