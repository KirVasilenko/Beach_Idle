using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UpgradePanel : MonoBehaviour
{
    public GameObject upgradeTemplatePrefab; 
    public Transform contentTransform; 
    public UpgradeItemSO[] upgrades;
    public UpgradeManager upgradeManager; 

    void Start()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            CreateUpgradeElement(i, upgrades[i]);
        }
    }

    void CreateUpgradeElement(int index, UpgradeItemSO upgrade)
    {
        GameObject upgradeElement = Instantiate(upgradeTemplatePrefab, contentTransform);
        UpgradeTemplate upgradeTemplate = upgradeElement.GetComponent<UpgradeTemplate>();
        if (upgradeTemplate != null)
        {
            upgradeTemplate.SetUpgrade(upgrade);
            upgradeTemplate.upgradeButton.onClick.AddListener(() => ApplyUpgrade(upgrade));
        }
    }

    void RemoveUpgrade(UpgradeItemSO upgrade)
    {
        int index = System.Array.IndexOf(upgrades, upgrade);
        if (index != -1)
        {
            upgrades = upgrades.Where((u, i) => i != index).ToArray();
            Transform upgradeTransform = contentTransform.GetChild(index);
            if (upgradeTransform != null)
            {
                Destroy(upgradeTransform.gameObject);
            }
        }
    }

    public void ApplyUpgrade(UpgradeItemSO upgrade)
    {
        upgradeManager.ApplyUpgrade(upgrade);
        RemoveUpgrade(upgrade);
    }
}
