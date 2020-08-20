using UnityEngine;

public class InputController : MonoBehaviour {
    public bool ShouldShoot() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) {
            return true;
        }
        return false;
    }

    public Direction GetPlayerDirection() {
        Direction playerDir = Direction.none;
        bool goLeft = false;
        bool goRight = false;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            goLeft = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            goRight = true;
        }

        if ((goRight && goLeft) || (!goRight && !goLeft)) {
            playerDir = Direction.none;
        } else {
            if (goLeft) {
                playerDir = Direction.left;
            }
            if (goRight) {
                playerDir = Direction.right;
            }
        }

        return playerDir;
    }
}
