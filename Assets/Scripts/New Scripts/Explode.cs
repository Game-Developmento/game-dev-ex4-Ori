// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Explode : MonoBehaviour
// {

//     // Start is called before the first frame update
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemey");
//             foreach (GameObject enemy in enemies)
//             {
//                 GameObject.Destroy(enemy);
//             }
//             Destroy(gameObject);
//         }
//     }
// }
