using UnityEngine;

public class GameController : MonoBehaviour {
    private enum Status {
        waiting,
        playing
    }

    private Status status;

    private void Start() {
        status = Status.waiting;
    }
}
