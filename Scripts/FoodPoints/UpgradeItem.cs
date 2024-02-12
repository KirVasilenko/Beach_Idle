// using UnityEngine;
// using UnityEngine.EventSystems;


// public class UpgradeItem : MonoBehaviour, IPointerClickHandler
// {
//     public ItemUpgrade itemToUpgrade;  
//     public ItemInfoPopupManager popupManager;
      

   
//     public void OnPointerClick(PointerEventData eventData)
//     {
        
//         if (itemToUpgrade != null && popupManager != null)
//         {
            
//             UpgradeItemLevel();

            
//             popupManager.ShowItemInfoPopup(itemToUpgrade);
//         }
//         else
//         {
//             Debug.LogWarning("Item or Popup Manager is not set.");
//         }
//     }

    
//     private void UpgradeItemLevel()
//     {
        
//         if (itemToUpgrade.level < itemToUpgrade.upgrades.Length)
//         {
//             itemToUpgrade.level++;
//             float upgradedCookingTime = itemToUpgrade.GetCookingTime();
//             float upgradedCost = itemToUpgrade.GetCost();
//             float upgradeCost = itemToUpgrade.GetUpgradeCost();

//             Debug.Log($"Upgraded to Level {itemToUpgrade.level} - Cooking Time: {upgradedCookingTime}, Cost: {upgradedCost}, Upgrade Cost: {upgradeCost}");
//         }
//         else
//         {
//             Debug.Log("Item is already at max level.");
//         }
//     }
// }
