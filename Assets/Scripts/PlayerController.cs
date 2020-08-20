using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("References")]
    public InputController input;
    public GameObject projectile;

    [Header("Movement")]
    public float maxLeftPos;
    public float maxRightPos;
    public float moveSpeed;
    
    [Header("Shooting")]
    public float shootCooldown;

    private float shootCooldownTimer;
    private bool canShoot;

    private void Update() {
        Movement();
        PlayAreaLock();
        Shooting();
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

    private void Shooting() {
        if (canShoot && input.ShouldShoot()) {
            ShootProjectile();
            canShoot = false;
        } else {
            shootCooldownTimer -= Time.deltaTime;

            if (shootCooldownTimer <= 0f) {
                shootCooldownTimer = shootCooldown;
                canShoot = true;
            }
        }
    }

    private void ShootProjectile() {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
