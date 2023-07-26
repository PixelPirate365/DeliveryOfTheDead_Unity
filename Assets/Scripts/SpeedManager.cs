using UnityEngine;

public class SpeedManager : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 20f;
    [SerializeField]
    private float slowSpeed = 15f;
    [SerializeField]
    private float boostSpeed = 30f;
    [SerializeField]
    public float CurrentSpeed { get; private set; }

    private void Start() {
        CurrentSpeed = moveSpeed;
    }

    public void SlowDown() {
        CurrentSpeed = slowSpeed;
    }

    public void SpeedUp() {
        CurrentSpeed = boostSpeed;
    }

    public void ReturnToNormalSpeed() {
        CurrentSpeed = moveSpeed;
    }
}