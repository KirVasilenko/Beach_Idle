using UnityEngine;
using UnityEngine.UI;

public class ObjectInfoPanel : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider developmentSlider;
    public Text costText;
    public Text timeText;
    public Button upgradeButton;

    private Item currentItem;

    public void ShowInfo(Item item)
    {
        currentItem = item;

        // Заполнение текстовых полей и слайдера данными из объекта Item
        nameText.text = item.itemName;
        levelText.text = "Level: " + item.tier.ToString();
        developmentSlider.value = CalculateDevelopmentProgress(item);
        costText.text = "Cost: " + item.GetUpgradeCost().ToString();
        timeText.text = "Time: " + CalculateTime(item);

        // Настройка кнопки улучшения
        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(UpgradeItem);
    }

    private float CalculateDevelopmentProgress(Item item)
    {
        // Расчет прогресса развития на основе уровня и общего количества уровней
        int maxLevel = item.upgradeTable.upgradeTiers.Length;
        return (float)item.tier / maxLevel;
    }

    private string CalculateTime(Item item)
    {
        // Здесь можно реализовать расчет времени приготовления
        // В данном примере просто возвращаем строку "N/A" (Not Available)
        return "N/A";
    }

    private void UpgradeItem()
    {
        // Вызов метода UpgradeItem у текущего объекта Item
        if (currentItem != null)
        {
            currentItem.UpgradeItem();
            // После апгрейда, обновляем информацию на панели
            ShowInfo(currentItem);
        }
    }
}
