using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Money Model", menuName = "Game/Money Model")]
public class MoneyModel : ScriptableObject
{
    [SerializeField] private float startingAmount = 0f;
    private BigInteger PlayerCoins;

    public BigInteger CurrentAmount => PlayerCoins;

    public void Initialize()
    {
        PlayerCoins = new BigInteger(startingAmount);
    }

    public void AddMoney(float amount)
    {
        PlayerCoins += new BigInteger(amount);
    }

    public bool SpendMoney(float amount)
    {
        if (PlayerCoins >= new BigInteger(amount))
        {
            PlayerCoins -= new BigInteger(amount);
            return true;  
        }

        return false;  
    }

    public string FormatAmount()
    {
        if (PlayerCoins < 1000)
        {
            return PlayerCoins.ToString();
        }

        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No" };
        int suffixIndex = 0;
        BigInteger formattedAmount = PlayerCoins;

        while (formattedAmount >= 1000)
        {
            formattedAmount /= 1000;
            suffixIndex++;
        }

        return $"{formattedAmount}{suffixes[suffixIndex]}";
    }
}
