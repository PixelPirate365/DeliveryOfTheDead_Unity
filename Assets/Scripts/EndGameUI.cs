using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour {
    public GameObject endGamePanel;
    public TextMeshProUGUI finishTime;
    public TextMeshProUGUI bestScoreText;
    public Button restartButton;
    public Button mainMenuButton;

    private TimerSystem timerSystem;

    private void Awake() {
        timerSystem = GetComponentInParent<TimerSystem>();

        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);

        endGamePanel.SetActive(false);
    }

    public void EndGame() {
        Time.timeScale = 0;

        finishTime.text = $"Finish Time: {timerSystem.TimeElapsedFormatted}";
        bestScoreText.text = $"Best Time: {timerSystem.FormatTime(PlayerPrefs.GetFloat("BestTime", 0))}";

        endGamePanel.SetActive(true);
    }

    private void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
   
}
