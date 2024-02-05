using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    public TMP_Text moneyText;  
    public MoneyModel moneyModel;  
    private void Start()
    {
        moneyModel.Initialize();
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        // moneyText.text = $"Money: {moneyModel.FormatAmount()}";
    }

    public void EarnMoney(float amount)
    {
        moneyModel.AddMoney(amount);
        UpdateMoneyDisplay();
    }

    public bool SpendMoney(float amount)
    {
        if (moneyModel.SpendMoney(amount))
        {
            UpdateMoneyDisplay();
            return true;  
        }

        Debug.LogWarning("Not enough money to spend.");
        return false;  
    }
}
