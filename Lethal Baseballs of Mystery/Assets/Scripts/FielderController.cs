using UnityEngine;

public class FielderController : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Baseball")) return;

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
