using System.Collections;
using UnityEngine;

public class Freeze : MonoBehaviour
{

    public GameObject[] enemies;


    // This method is called when the GameObject collides with another GameObject with a 2D Collider component
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the FreezeEnemies coroutine and destroy this GameObject
            StartCoroutine(FreezeEnemies());
            Destroy(gameObject);
        }
    }
    IEnumerator FreezeEnemies()
    {
        // Find all GameObjects with the "Enemy" tag and add them to the array
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Loop through all the enemies and freeze them
        foreach (GameObject enemy in enemies)
        {
            if (enemy && enemy.activeSelf && enemy.transform.position.y > -1.5f) // check that enemeis are not too low
            {
                Mover mover = enemy.GetComponent<Mover>();
                if (mover)
                {
                    mover.SetVelocity(Vector3.zero); // set velocity to zero
                }
            }
        }
        yield return null;

    }
}