using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("level-1-power-ups");
    }
}
