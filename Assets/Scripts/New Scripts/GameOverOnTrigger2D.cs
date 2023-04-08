using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Debug.Log("Game over!");
            this.gameObject.SetActive(false);
            GameObject[] enemeis = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemeis) {
                enemy.SetActive(false);
            }
        }
    }



}
