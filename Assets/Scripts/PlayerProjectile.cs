using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    public float moveSpeed;
    public float destroyHeight;

    private void Update() {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime);

        if (transform.position.y >= destroyHeight) {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
