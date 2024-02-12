using System.Collections;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject[] clientPrefabs;
    public int maxSpawnedClients = 5;
    public float spawnDelay = 3f;

    private void Start()
    {
        StartCoroutine(SpawnCharactersWithDelay());
    }

    private IEnumerator SpawnCharactersWithDelay()
    {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Spawn");

        if (spawnPoint != null)
        {
            for (int i = 0; i < maxSpawnedClients; i++)
            {
                GameObject characterPrefab = clientPrefabs[Random.Range(0, clientPrefabs.Length)];
                Vector3 spawnPosition = spawnPoint.transform.position;

                Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnDelay);
            }
        }
        else
        {
            Debug.LogError("Spawn point not found!");
        }
    }
}
