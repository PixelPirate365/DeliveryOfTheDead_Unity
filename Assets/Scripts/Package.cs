using UnityEngine;

public class Package : MonoBehaviour {
    private bool isPickedUp = false;

    public bool IsPickedUp {
        get { return isPickedUp; }
    }

    public void PickUp() {
        if (!isPickedUp) {
            isPickedUp = true;
            // Play sound if desired
            GetComponent<Collider2D>().enabled = false;
            // Deactivate the sprite renderer
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}