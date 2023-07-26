using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public PointSystem pointSystem;
    public TimerSystem timerSystem;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public SpeedManager speedManager;

    void Update() {
       
        scoreText.text = "Score: " + pointSystem.CurrentPackages + "/" + pointSystem.TotalPackages;
        timerText.text = "Time: " + timerSystem.TimeElapsedFormatted;
    }
}
