using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    

    private void Start()
    {
        Debug.Log("Max Cherries" + GameObject.FindGameObjectsWithTag("Cherry").Length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var cherriesCollected = GameObject.FindGameObjectsWithTag("Cherry").Length;
        Debug.Log("Cherries" + cherriesCollected);
        if (cherriesCollected <= 1)
        {
            Debug.Log("All Cherries Collected...");
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Ayayaya");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
