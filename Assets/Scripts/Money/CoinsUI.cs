using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    public CoinManager coinManager;
    public TMP_Text coinsText;

    private void Start()
    {
        // Получаем ссылку на компонент CoinManager, если он не был присвоен в инспекторе
        if (coinManager == null)
        {
            coinManager = FindObjectOfType<CoinManager>();
        }

        UpdateCoinsUI();
    }

    // Обновляем отображение количества монет
    private void UpdateCoinsUI()
    {
        if (coinsText != null && coinManager != null)
        {
            coinsText.text = coinManager.Coins.ToString();
        }
    }

    // Подписываемся на событие изменения количества монет для обновления UI
    private void OnEnable()
    {
        if (coinManager != null)
        {
            coinManager.OnCoinsChanged += UpdateCoinsUI;
        }
    }

    // Отписываемся от события при выключении объекта
    private void OnDisable()
    {
        if (coinManager != null)
        {
            coinManager.OnCoinsChanged -= UpdateCoinsUI;
        }
    }
}
