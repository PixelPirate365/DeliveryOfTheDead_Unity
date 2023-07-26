using UnityEngine;

public class DeliveryCollisionHandler : MonoBehaviour {
    private Delivery delivery;
    public AudioSource deliveredSound;

    private void Awake() {
        if (delivery == null) {
            delivery = GetComponent<Delivery>();
            if (delivery == null) {
                Debug.LogError("Delivery component is missing on this object");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Package") && !delivery.HasPackage) {
            Debug.Log("picked up package");
            collision.GetComponent<Package>().PickUp();
            delivery.PickupPackage();
            deliveredSound.Play();
        }
        else if (collision.CompareTag("Customer") && delivery.HasPackage) {
            Debug.Log("delivered package");
            collision.GetComponent<Customer>().ReceivePackage();
            delivery.DeliverPackage();
            deliveredSound.Play();
        }
    }
}
