using UnityEngine;

public class BaseballController : MonoBehaviour {

    public float Speed;
    public GameObject[] Fielders = new GameObject[7];
    public Transform PitchTarget;

    GameManager GM;
    BatterController Batter;
    PitcherController Pitcher;
    Transform PositionToMoveTo;

	void Start() {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Batter = GM.GetBatter();
        Pitcher = GM.GetPitcher();
        PositionToMoveTo = GM.GetPitchTarget();

        Fielders = GM.Fielders;

        GM.SetBaseball(gameObject);

        Destroy(gameObject, 10);
	}
	
	void Update() {
        MoveToPosition(PositionToMoveTo);
	}

    void OnDestroy() {
        Batter.SetHasSwung(false);
        Pitcher.ResetCanPitch();
        Pitcher.ResetHasPitched();
        PositionToMoveTo = GM.GetPitchTarget();
        GM.NewBatter();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("HitterBox")) {
            gameObject.GetComponent<MeshRenderer>().material = Pitcher.GetCurrentBallMaterial();
        }
    }

    public void MoveToPosition(Transform targetPosition) {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition.position,
            Speed * Time.deltaTime);
    }

    public void SetPositionToMoveTo(Transform pos) {
        PositionToMoveTo = pos;
    }
}
