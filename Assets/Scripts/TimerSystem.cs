using System;
using UnityEngine;

public class TimerSystem : MonoBehaviour {
    private float timeElapsed = 0;
    private float bestTime = float.MaxValue;
    private bool isTiming = false;

    public string TimeElapsedFormatted => FormatTime(timeElapsed);
    public string BestTimeFormatted => FormatTime(bestTime);

    private void Update() {
        if (isTiming && Time.timeScale != 0) { 
            timeElapsed += Time.deltaTime;
        }
    }

    public void StartTimer() {
        isTiming = true;
    }

    public void StopTimer() {
        isTiming = false;
        if (timeElapsed < bestTime) {
            bestTime = timeElapsed;
            Debug.Log($"New best time: {BestTimeFormatted}");
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        timeElapsed = 0;
    }

    public string FormatTime(float timeInSeconds) {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}.{2:F0}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10.0);
    }

}