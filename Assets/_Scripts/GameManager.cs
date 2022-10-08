using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] int timeToEnd = 30;

    [SerializeField] int points = 0, redKey = 0, greenKey = 0, goldKey = 0;

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

    public void AddPoints(int _points) => points += _points;

    public void AddTime(int _time) => timeToEnd += _time;

    public void FreezeTime(int _freeze)
    {
        Debug.Log("frozen");
        CancelInvoke("Timer");
        InvokeRepeating("Timer", _freeze, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold) goldKey++; 
        else if (color == KeyColor.Red) redKey++;
        else if (color == KeyColor.Green) greenKey++;
    } 
}
