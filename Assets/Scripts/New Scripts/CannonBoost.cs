using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBoost : MonoBehaviour
{
    [Tooltip("The numer of seconds the boost is active")][SerializeField] float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var clickSpawner = other.GetComponent<ClickSpawner>();
            if (clickSpawner)
            {
                clickSpawner.StartCoroutine(cannonTemporarily(clickSpawner));
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Cannon triggered by " + other.name);
        }
    }
    private IEnumerator cannonTemporarily(ClickSpawner clickSpawner)
    {
        clickSpawner.setUseAlternatePrefab(true);
        yield return new WaitForSeconds(duration);
        clickSpawner.setUseAlternatePrefab(false);
    }
}
