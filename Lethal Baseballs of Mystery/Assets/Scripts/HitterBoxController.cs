using UnityEngine;

public class HitterBoxController : MonoBehaviour {

    GameManager GM;

    void Start() {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Baseball")) return;

        GM.SetBallInHitBox(true);
    }

    void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Baseball")) return;

        GM.SetBallInHitBox(false);
        GM.SetBallExitedHitBox(true);

        if (!GM.GetBatter().HasHitBall()) {
            Destroy(other.gameObject, 0.75f);
        }
    }
}
