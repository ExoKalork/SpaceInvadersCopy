using UnityEngine;

public class PlayerController : MonoBehaviour {
    // References
    public InputController input;
    
    // Settings
    public float maxLeftPos;
    public float maxRightPos;
    public float moveSpeed;
    
    private void Update() {
        Movement();
        PlayAreaLock();
    }
    
    private void Movement() {
        Direction dirInput = input.GetPlayerDirection();

        if (dirInput == Direction.none) {
            return;
        }

        Vector3 dir = dirInput == Direction.right ? transform.right : -transform.right;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    private void PlayAreaLock() {
        Vector2 pos = transform.position;

        if (pos.x > maxRightPos) {
            pos.x = maxRightPos;
        }
        if (pos.x < maxLeftPos) {
            pos.x = maxLeftPos;
        }

        transform.position = pos;
    }
}
