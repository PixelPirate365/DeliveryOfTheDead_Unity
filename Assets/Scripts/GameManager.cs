using UnityEngine;

public class GameManager : MonoBehaviour {
    private PointSystem pointSystem;
    private TimerSystem timerSystem;
    public GameObject carObject;
    private bool gameRun = false;

    private void Start() {
        pointSystem = GetComponent<PointSystem>();
        timerSystem = GetComponent<TimerSystem>();
    }
    private void Update() {
        
    }
    public void StartGame() {
        if (!gameRun) {
            pointSystem.Reset();
            gameRun = true;
            timerSystem.StartTimer();
        }
    }

    public void EndGame() {
        GetComponentInChildren<EndGameUI>().EndGame();
        timerSystem.StopTimer();
        carObject.GetComponent<Driver>().DisableMovement();
        gameRun = false;
    }
    
}
