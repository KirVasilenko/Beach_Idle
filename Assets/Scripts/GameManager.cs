using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CoinManager coinManager;
    [SerializeField] public int startingCoins = 5;

    private void Start()
    {
        if (coinManager != null)
        {
            coinManager.AddCoins(startingCoins);
        }
        else
        {
            Debug.LogError("CoinManager not assigned to GameManager!");
        }
    }
}
