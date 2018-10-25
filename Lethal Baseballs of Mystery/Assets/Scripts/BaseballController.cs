using UnityEngine;

public class BaseballController : MonoBehaviour {

    public float Speed;
    public GameObject[] Fielders = new GameObject[7];
    public Transform PitchTarget;

    GameManager GM;
    BatterController BC;
    Transform PositionToMoveTo;

	void Start() {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //PositionToMoveTo = GameObject.FindWithTag("Batter").transform;
        PositionToMoveTo = GM.GetPitchTarget();

        Fielders = GM.Fielders;

        Destroy(gameObject, 5f);
	}
	
	void Update() {
        MoveToPosition(PositionToMoveTo);

        //if (transform.position == PositionToMoveTo.position) {
        //    Destroy(gameObject);
        //}
	}

    void OnDestroy() {
        BC.SetHasSwung(false);
    }

    //void OnTriggerEnter(Collider other) {
    //    if (other.gameObject.CompareTag("Batter")) {
    //        int random = Random.Range(0, 7);

    //        PositionToMoveTo = Fielders[random].transform;
    //    }
    //}

    public void MoveToPosition(Transform targetPosition) {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition.position,
            Speed * Time.deltaTime);
    }
}
