using UnityEngine;
using UnityEngine.AI;

public class ClientNavigation : MonoBehaviour
{
    public Transform barCounter;
    public float moveSpeed = 3f;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SpawnInsideSpawnZone();
    }

    private void SpawnInsideSpawnZone()
    {
        
        GameObject[] spawnZones = GameObject.FindGameObjectsWithTag("spawn");

        if (spawnZones.Length > 0)
        {
            
            GameObject spawnZone = spawnZones[Random.Range(0, spawnZones.Length)];

            
            Collider spawnCollider = spawnZone.GetComponent<Collider>();
            if (spawnCollider != null)
            {
                Vector3 spawnPoint = GetRandomPointInBounds(spawnCollider.bounds);

                
                transform.position = spawnPoint;

                
                navMeshAgent.SetDestination(barCounter.position);
            }
        }
        else
        {
            Debug.LogError("No spawn zones found");
        }
    }

    private Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            0f,
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
