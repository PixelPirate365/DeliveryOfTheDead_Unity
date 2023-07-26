using UnityEngine;

public class Driver : MonoBehaviour {

    [SerializeField]
    private float steerSpeed = 300f;

    private SpeedManager speedManager;
    private GameManager gameManager;
    public AudioSource engineSound;
    ParticleSystem exhaustParticles;
    float engineStopSoundDelay = 2f;
    private bool canMove = true;

    private void Awake() {
        exhaustParticles = GetComponentInChildren<ParticleSystem>();
        speedManager = GetComponent<SpeedManager>();
        if (speedManager == null) {
            Debug.LogError("SpeedManager component is missing on this object");
        }
    }

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update() {
        if (canMove) {
            float moveAmount = Input.GetAxis("Vertical") * speedManager.CurrentSpeed * Time.deltaTime;

            if (moveAmount == 0) {
                Invoke("StopEngineAndParticles", engineStopSoundDelay);
            }
            else {
                CancelInvoke("StopEngineAndParticles");
                float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
                transform.Rotate(0, 0, -steerAmount);
                transform.Translate(0, moveAmount, 0);
                if (!engineSound.isPlaying) {
                    engineSound.Play();
                }
                if (!exhaustParticles.isPlaying) {
                    exhaustParticles.Play();
                }
            }
        }
    }
    private void StopEngineAndParticles() {
        if (engineSound.isPlaying) {
            engineSound.Stop();
        }
        if (exhaustParticles.isPlaying) {
            exhaustParticles.Stop();
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("StartTimerObject")) {
            gameManager.StartGame();
            canMove = true;
        }
    }
    public void DisableMovement() {
        canMove = false;
    }
}