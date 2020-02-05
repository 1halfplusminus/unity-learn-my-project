using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public MonoBehaviour playerController;
    public SpawnManager spawnManager;
    bool gameOver = false;

    public UnityEvent onGameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            playerController.enabled = false;
            spawnManager.Stop();
            onGameOver.Invoke();
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
