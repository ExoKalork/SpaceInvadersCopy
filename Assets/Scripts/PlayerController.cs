using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [Header("References")]
    public InputController input;
    public GameObject projectile;
    public Text debug1;

    [Header("Movement")]
    public float maxLeftPos;
    public float maxRightPos;
    public float moveSpeed;
    
    [Header("Shooting")]
    public float shootCooldown;
    public Vector2 projectileSpawnOffset;

    private float shootCooldownTimer;
    private bool canShoot;

    private void Update() {
        Movement();
        PlayAreaLock();
        Shooting();
        debug1.text = "Cooldown : " + shootCooldownTimer;
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
        if (canShoot) {
            if (input.ShouldShoot()) {
                ShootProjectile();
                canShoot = false;
            }
        } else {
            shootCooldownTimer -= Time.deltaTime;

            if (shootCooldownTimer <= 0f) {
                shootCooldownTimer = shootCooldown;
                canShoot = true;
            }
        }
    }

    private void ShootProjectile() {
        Instantiate(projectile, (Vector2)transform.position + projectileSpawnOffset, Quaternion.identity);
    }
}
