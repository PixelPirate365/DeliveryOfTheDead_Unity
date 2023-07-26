using System.Collections;
using UnityEngine;


[RequireComponent(typeof(SpeedManager))]
public class SpeedCollisionHandler : MonoBehaviour {
    SpeedManager speedManager;
    [SerializeField] float slowDelay = 2f;
    [SerializeField] float speedDelay = 2f;
    [SerializeField] float powerUpDeactivationTime = 10f;
    public AudioSource crashSound;
    public AudioSource powerUpSound;

    private void Awake() {
        speedManager = GetComponent<SpeedManager>();
        if (speedManager == null) {
            Debug.LogError("SpeedManager component is missing on this object");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Asset")) {
            speedManager.SlowDown();
            Invoke("ResetSpeed", slowDelay);
            crashSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("SpeedUp")) {
            speedManager.SpeedUp();
            Invoke("ResetSpeed", speedDelay);
            powerUpSound.Play();
            collision.gameObject.SetActive(false);
            StartCoroutine(ReactivatePowerUp(collision.gameObject, powerUpDeactivationTime));
        }
    }

    private void ResetSpeed() {
        speedManager.ReturnToNormalSpeed();
    }

    private IEnumerator ReactivatePowerUp(GameObject powerUp, float delay) {
        yield return new WaitForSeconds(delay);
        powerUp.SetActive(true);
    }
}