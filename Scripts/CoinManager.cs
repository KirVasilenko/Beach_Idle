using UnityEngine;
using System;

public class CoinManager : MonoBehaviour
{
    private int coins = 0;
    public event Action OnCoinsChanged;

    public int Coins => coins;

    // Метод для пополнения счета на указанную сумму
    public void AddCoins(int amount)
    {
        coins += amount;
        OnCoinsChanged?.Invoke();
        Debug.Log("Coins added: " + amount);
    }

    // Метод для списания с счета указанной суммы
    public bool DeductCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            OnCoinsChanged?.Invoke();
            Debug.Log("Coins deducted: " + amount);
            return true;
        }
        else
        {
            Debug.LogWarning("Insufficient coins!");
            return false;
        }
    }
}
