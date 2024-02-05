using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Money Model", menuName = "Game/Money Model")]
public class MoneyModel : ScriptableObject
{
    [SerializeField] private float startingAmount = 0f;
    private BigInteger currentAmount;

    public BigInteger CurrentAmount => currentAmount;

    public void Initialize()
    {
        currentAmount = new BigInteger(startingAmount);
    }

    public void AddMoney(float amount)
    {
        currentAmount += new BigInteger(amount);
    }

    public bool SpendMoney(float amount)
    {
        if (currentAmount >= new BigInteger(amount))
        {
            currentAmount -= new BigInteger(amount);
            return true;  
        }

        return false;  
    }

    public string FormatAmount()
    {
        if (currentAmount < 1000)
        {
            return currentAmount.ToString();
        }

        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No" };
        int suffixIndex = 0;
        BigInteger formattedAmount = currentAmount;

        while (formattedAmount >= 1000)
        {
            formattedAmount /= 1000;
            suffixIndex++;
        }

        return $"{formattedAmount}{suffixes[suffixIndex]}";
    }
}
