using UnityEngine;

public class PointSystem : MonoBehaviour {
    public int TotalPackages { get; set; } = 12;
    public int CurrentPackages { get; private set; } = 0;

    private GameManager gameManager;

    private void Awake() {
        gameManager = GetComponent<GameManager>();
    }

    public void PackageDelivered() {
        CurrentPackages++;
        if (CurrentPackages >= TotalPackages) {
            Debug.Log("All packages delivered!");
            gameManager.EndGame();
        }
    }

    public void Reset() {
        CurrentPackages = 0;
    }
}
