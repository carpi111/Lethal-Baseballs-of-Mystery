using UnityEngine;

public class BatterController : MonoBehaviour {

    public float RunSpeed;
    public Vector3 PosAdjustment;

    GameManager GM;

    GameObject FirstBase;
    GameObject SecondBase;
    GameObject ThirdBase;
    GameObject HomeBase;
    GameObject BaseToMoveTo;

    bool HasSwung;

	void Start() {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        FirstBase  = GameObject.FindWithTag("FirstBase");
        SecondBase = GameObject.FindWithTag("SecondBase");
        ThirdBase  = GameObject.FindWithTag("ThirdBase");
        HomeBase   = GameObject.FindWithTag("HomeBase");

        transform.position = HomeBase.transform.position + PosAdjustment;
        BaseToMoveTo = HomeBase;
    }

    void Update() {
        //if (Input.GetKeyDown(KeyCode.Alpha1)) {
        //    BaseToMoveTo = FirstBase;
        //} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
        //    BaseToMoveTo = SecondBase;
        //} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
        //    BaseToMoveTo = ThirdBase;
        //} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
        //    BaseToMoveTo = HomeBase;
        //}

        //HasSwung |= Input.GetKeyDown(KeyCode.Space);

        CheckSwing();

        //MoveToBase(BaseToMoveTo);
    }

    void MoveToBase(GameObject targetBase) {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetBase.transform.position + PosAdjustment,
            RunSpeed * Time.deltaTime);
    }

    public void SetBaseToMoveTo(GameObject targetBase) {
        BaseToMoveTo = targetBase;
    }

    void CheckSwing() {

        if (GM.BallIsInHitBox()) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                // TODO: HIT BALL
                HasSwung = true;
                print("SWUNG");
            }
        } else if (GM.BallDidExitHitBox()) {
            if (HasSwung) {
                // TODO: RUN TO BASE
            } else {
                GM.AddStrike();
            }
        }

        //HasSwung = false;
        GM.SetBallExitedHitBox(false);
    }

    public bool PlayerHasSwung() {
        return HasSwung;
    }

    public void SetHasSwung(bool val) {
        HasSwung = val;
    }
}
