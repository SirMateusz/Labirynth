using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] int timeToEnd = 30;

    [SerializeField]
    private Text timeText, goldKeyText, redKeyText, greenKeyText, crystalText, pauseText, infoText, UseText;

    [SerializeField]
    private Image snowFlake;

    [SerializeField]
    private Image healthImage;

    [SerializeField]
    private GameObject infoPanel;

    [SerializeField]
    private int Health = 100;

    public int points = 0, redKey = 0, greenKey = 0, goldKey = 0;

    bool isPaused = false, endGame = false, win = false;

    void Start()
    {
        if (gameManager == null) { gameManager = this; DontDestroyOnLoad(this.gameObject); }
        else Destroy(this.gameObject);

        if (timeToEnd <= 0) timeToEnd = 30;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        infoPanel.SetActive(false);
        snowFlake.enabled = false;
        SetTimeText();
        SetUseText("");
        pauseText.gameObject.SetActive(false);

        Time.timeScale = 1f;

        InvokeRepeating("Timer", 2f, 1f);
    }

    private string CorrectTime(int _time)
    {
        string result = string.Empty;

        if (_time < 10) result = $"0{_time}";
        else result = _time.ToString();

        return result;
    }

    public void WinGame() { win = true; endGame = true; }

    private void SetTimeText()
    {
        TimeSpan ts = TimeSpan.FromSeconds(timeToEnd);

        timeText.text = $"{CorrectTime(ts.Minutes)}:{CorrectTime(ts.Seconds)}";
    }

    public void SetUseText(string _text)
    {
        UseText.text = _text;
    }

    public void TakeDamage(int _damage)
    {
        Health -= _damage;

        if (Health <= 0) EndGame();
    }

    public void UpdateUI()
    {
        crystalText.text = points.ToString();
        goldKeyText.text = goldKey.ToString();
        greenKeyText.text = greenKey.ToString();
        redKeyText.text = redKey.ToString();
        healthImage.fillAmount = (float)Health/100;
    }

    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused) ResumeGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) PauseGame();
    }

    void Timer()
    {
        timeToEnd--;
        SetTimeText();
        Debug.Log($"Time: {timeToEnd}s");
        if (timeToEnd <= 0) { timeToEnd = 0; endGame = true; }
        if (endGame) EndGame();
    }

    void PauseGame()
    {
        AudioController.audioController.Play("pause");
        Debug.Log("Game Paused");
        pauseText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        AudioController.audioController.Play("resume");
        Debug.Log("Game Resumed");
        pauseText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void EndGame() 
    {
        CancelInvoke("Timer");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (win)
        {
            AudioController.audioController.Play("win");
            infoPanel.SetActive(true);
            infoText.text = "You WIN!!!";
        }
        else
        {
            AudioController.audioController.Play("loose");
            infoPanel.SetActive(true);
            infoText.text = "You LOSE!!!";
        }
    } 

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
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
