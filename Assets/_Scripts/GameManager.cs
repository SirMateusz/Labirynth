using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] int timeToEnd = 30;

    bool isPaused = false, endGame = false, win = false;

    void Start()
    {
        if (gameManager == null) { gameManager = this; DontDestroyOnLoad(this.gameObject); }
        else Destroy(this.gameObject);

        if (timeToEnd <= 0) timeToEnd = 30;

        InvokeRepeating("Timer", 2f, 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused) ResumeGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) PauseGame();
    }

    void Timer()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");
        if (timeToEnd <= 0) { timeToEnd = 0; endGame = true; }
        if (endGame) EndGame();
    }

    void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        isPaused = false;
    }

    void EndGame() 
    {
        CancelInvoke("Timer");
        if (win) Debug.Log("You win");
        else Debug.Log("You lose");
    }
}
