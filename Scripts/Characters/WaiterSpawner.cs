using UnityEngine;
using System.Collections.Generic;

public class WaiterSpawner : MonoBehaviour
{
    public GameObject waiterPrefab; 
    private Queue<WaiterMovement> waiterQueue = new Queue<WaiterMovement>(); 
    private bool hasSpawned = false; 

    private void Start()
    {
        SpawnWaiter();
    }

    private void SpawnWaiter()
    {
        
        if (!hasSpawned)
        {
            
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnWaiters");

            if (spawnPoints.Length > 0)
            {
                
                GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                
                GameObject waiterObject = Instantiate(waiterPrefab, spawnPoint.transform.position, Quaternion.identity);
                
                
                WaiterMovement waiterMovement = waiterObject.GetComponent<WaiterMovement>();
                waiterQueue.Enqueue(waiterMovement);
                
                hasSpawned = true;
            }
            else
            {
                Debug.LogError("No spawn points found with tag 'SpawnWaiters'");
            }
        }
    }

    public void SpawnWaiterOnCommand()
    {
        SpawnWaiter();
    }

    public void AssignTargetToWaiter(TargetPoint target)
    {
        if (waiterQueue.Count > 0)
        {
            WaiterMovement waiter = waiterQueue.Dequeue();
            
        }
        

    }
}
