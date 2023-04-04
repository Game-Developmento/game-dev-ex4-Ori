using System.Collections;
using UnityEngine;
using System.Collections.Generic;


/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")][SerializeField] float maxXDistance = 0.5f;
    [Tooltip("Maximum distance in Y between spawner and spawned objects, in meters")][SerializeField] float maxYDistance = 0f;
    [Tooltip("Maximum distance in Z between spawner and spawned objects, in meters")][SerializeField] float maxZDistance = 0f;

    private bool activeRespawn = true;

    private List<GameObject> spawnedObj = new List<GameObject>();


    public void setActiveRespawn(bool value)
    {
        this.activeRespawn = value;
    }

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());    // co-routines
        // _ = SpawnRoutine();                   // async-await
    }

    private bool isValidPosition(Vector3 currPos, float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(currPos, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return false;
            }
        }
        return true;
    }

    public List<GameObject> GetSpawnedObjects()
    {
        return this.spawnedObj;
    }
    IEnumerator SpawnRoutine()
    {    // co-routines
         // async Task SpawnRoutine() {  // async-await
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y + Random.Range(-maxYDistance, +maxYDistance),
                transform.position.z + Random.Range(-maxZDistance, +maxZDistance));
            Debug.Log(activeRespawn);
            if (isValidPosition(positionOfSpawnedObject, 2f) && activeRespawn)
            {
                GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
                newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
                spawnedObj.Add(newObject);
            }
        }
    }
}
