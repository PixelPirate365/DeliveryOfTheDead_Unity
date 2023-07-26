using UnityEngine;

public class Delivery : MonoBehaviour {
    [SerializeField]
    Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    public bool HasPackage { get; private set; }

    private PointSystem pointSystem;
    private GameManager gameManager;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        pointSystem = gameManager.GetComponent<PointSystem>();
    }


    public void PickupPackage() {
        HasPackage = true;
        spriteRenderer.color = hasPackageColor;
    }

    public void DeliverPackage() {
        HasPackage = false;
        spriteRenderer.color = noPackageColor;
        pointSystem.PackageDelivered();
    }
}