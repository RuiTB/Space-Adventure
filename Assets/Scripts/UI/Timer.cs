using Assets.Scripts;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                FindObjectsOfType<Spawner>().First().EndGame();
                SceneManager.LoadScene("EndGameScreen");
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}