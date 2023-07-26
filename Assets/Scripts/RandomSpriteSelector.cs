using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class RandomSpriteSelector : MonoBehaviour {
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polyCollider;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    void Start() {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        UpdateCollider();
    }

    void UpdateCollider() {
        Destroy(polyCollider);
        polyCollider = gameObject.AddComponent<PolygonCollider2D>();
        if (tag == "Customer")
            polyCollider.isTrigger = true;

    }
}