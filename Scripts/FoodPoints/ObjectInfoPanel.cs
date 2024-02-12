// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ObjectInfoPanel : MonoBehaviour
// {
//     public TextMeshPro nameText;
//     public TextMeshPro levelText;
//     public Slider developmentSlider;
//     public TextMeshPro FoodCostText;
//     public TextMeshPro timeText;
//     public Button upgradeButton;

//     private Item currentItem;

//     public void ShowInfo(Item item)
//     {
//         currentItem = item;

//         nameText.text = item.itemName;
//         levelText.text = "Level: " + item.tier.ToString();
//         developmentSlider.value = CalculateDevelopmentProgress(item);
//         FoodCostText.text = "Cost: " + item.GetUpgradeCost().ToString();
//         timeText.text = "Time: " + CalculateTime(item);

        
//         upgradeButton.onClick.RemoveAllListeners();
//         upgradeButton.onClick.AddListener(UpgradeItem); 
//     }

//     private float CalculateDevelopmentProgress(Item item)
//     {
        
//         int maxLevel = item.upgradeTable.upgradeTiers.Length;
//         return (float)item.tier / maxLevel;
//     }

//     private string CalculateTime(Item item)
//     {
//         return "N/A";
//     }

//     private void UpgradeItem()
//     {
        
//         if (currentItem != null)
//         {
//             currentItem.UpgradeItem();
            
//             ShowInfo(currentItem);
//         }
//     }
// }
