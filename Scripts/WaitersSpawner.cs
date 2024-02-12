using UnityEngine;

public class WaitersSpawn : MonoBehaviour
{
    public GameObject waiterPrefab;

    private bool canSpawn = false;

    private void Update()
    {
        // Проверяем, можно ли спаунить новых официантов при нажатии кнопки
        if (canSpawn && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnWaiter();
        }
    }

    // Метод для спауна официанта
    private void SpawnWaiter()
    {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnWaiters");
        if (spawnPoint != null)
        {
            Vector3 spawnPosition = spawnPoint.transform.position;
            GameObject spawnedWaiter = Instantiate(waiterPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Spawn point for waiters not found!");
        }
    }

    // Метод для установки возможности спауна официантов
    public void SetCanSpawn(bool value)
    {
        canSpawn = value;
    }
}
