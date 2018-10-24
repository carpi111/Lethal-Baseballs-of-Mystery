using UnityEngine;

public class BatterController : MonoBehaviour {

    public float RunSpeed;
    public Vector3 PosAdjustment;

    GameObject FirstBase;
    GameObject SecondBase;
    GameObject ThirdBase;
    GameObject HomeBase;

    GameObject BaseToMoveTo;

    GameManager GM;

	void Start () {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        FirstBase  = GameObject.FindWithTag("FirstBase");
        SecondBase = GameObject.FindWithTag("SecondBase");
        ThirdBase  = GameObject.FindWithTag("ThirdBase");
        HomeBase   = GameObject.FindWithTag("HomeBase");

        transform.position = HomeBase.transform.position + PosAdjustment;
        BaseToMoveTo = HomeBase;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            BaseToMoveTo = FirstBase;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            BaseToMoveTo = SecondBase;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            BaseToMoveTo = ThirdBase;
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            BaseToMoveTo = HomeBase;
        }

        MoveToBase(BaseToMoveTo);
    }

    void MoveToBase(GameObject targetBase) {
        transform.position = Vector3.MoveTowards(transform.position, targetBase.transform.position + PosAdjustment, RunSpeed * Time.deltaTime);
    }

    public void SetBaseToMoveTo(GameObject targetBase) {
        BaseToMoveTo = targetBase;
    }

    // check for player swing
    // if SPACE is hit, check if ball is in hit box
        // if so, hit ball
        // if not, strike
    void CheckSwing() {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (GM.IsBallInHitBox()) {
            // hit ball
        } else {
            // strike
        }
    }
}
