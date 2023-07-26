using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGameUI : MonoBehaviour {
    public GameObject pauseGamePanel;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentTimeText;
    public Button resumeButton;
    public Button mainMenuButton;

    private bool isGamePaused = false;
    private TimerSystem timerSystem;
    private PointSystem pointSystem;

    private void Awake() {
        timerSystem = GetComponentInParent<TimerSystem>();
        pointSystem = GetComponentInParent<PointSystem>();

        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);

        pauseGamePanel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }

        currentScoreText.text = $"Current Score: {pointSystem.CurrentPackages}";
        currentTimeText.text = $"Current Time: {timerSystem.TimeElapsedFormatted}";
    }

    private void GoToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    private void PauseGame() {
        Time.timeScale = 0;
        pauseGamePanel.SetActive(true);
        isGamePaused = true;
    }

    private void ResumeGame() {
        Time.timeScale = 1;
        pauseGamePanel.SetActive(false);
        isGamePaused = false;
    }
}
