using UnityEngine;

public class BatterController : MonoBehaviour {

    public float RunSpeed;
    public Vector3 XPosAdjustment;
    public Vector3 ZPosAdjustment;
    public Material BadBallMaterial;

    GameManager GM;
    PitcherController Pitcher;

    GameObject FirstBase;
    GameObject SecondBase;
    GameObject ThirdBase;
    GameObject HomeBase;
    GameObject CurrentBase;
    GameObject BaseToMoveTo;
    Transform GoodHitTarget;

    bool HasSwung;
    bool CanSwing;
    bool MovingToBase;
    bool HitBall;
    bool NeedsNewBatter;
    bool IsRunner;

	void Start() {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Pitcher       = GM.GetPitcher();
        FirstBase     = GameObject.FindWithTag("FirstBase");
        SecondBase    = GameObject.FindWithTag("SecondBase");
        ThirdBase     = GameObject.FindWithTag("ThirdBase");
        HomeBase      = GameObject.FindWithTag("HomeBase");
        GoodHitTarget = GameObject.FindWithTag("GoodHitTarget").transform;
        CurrentBase = HomeBase;

        transform.position = HomeBase.transform.position
            + XPosAdjustment
            + ZPosAdjustment;
        BaseToMoveTo = HomeBase;
    }

    void Update() {
        if (!IsRunner) {
            CheckSwing();
        }

        if (!HitBall) {
            transform.position = HomeBase.transform.position
                + XPosAdjustment
                + ZPosAdjustment;
        } else {
            MoveToBase(BaseToMoveTo);
        }
    }

    void MoveToBase(GameObject targetBase) {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetBase.transform.position + ZPosAdjustment,
            RunSpeed * Time.deltaTime);
        CurrentBase = targetBase;

        if (transform.position == targetBase.transform.position) {
            SetNextBase();
            GM.SetNeedsNewBatter(true);
        }
    }

    public void SetBaseToMoveTo(GameObject targetBase) {
        BaseToMoveTo = targetBase;
    }

    void CheckSwing() {
        if (GM.BallIsInHitBox()) {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            if (Pitcher.GetCurrentBallMaterial() != BadBallMaterial) {
                GM.GetBaseball().SetPositionToMoveTo(GoodHitTarget);
                GM.GetBaseball().Speed *= 2;
            } else {
                Transform RandFielder = GM.GetRandomFielderPosition();
                GM.GetBaseball().SetPositionToMoveTo(RandFielder);
            }

            HasSwung = true;
            HitBall = true;
            print("SWUNG");
            MovingToBase = true;
            IsRunner = true;

            BaseToMoveTo = FirstBase;
            CurrentBase = FirstBase;

        } else if (GM.BallDidExitHitBox()) {
            if (!HasSwung){
                if (Pitcher.GetCurrentBallMaterial() != BadBallMaterial) {
                    HitBall = false;
                    GM.AddStrike();
                }

                Destroy(GM.GetBaseball().gameObject, 0.65f);
            }
        }

        GM.SetBallExitedHitBox(false);
    }

    void MoveToNextBase() {
        switch (CurrentBase.tag) {
            case "HomeBase":
                BaseToMoveTo = FirstBase;
                break;
            case "FirstBase":
                BaseToMoveTo = SecondBase;
                break;
            case "SecondBase":
                BaseToMoveTo = ThirdBase;
                break;
            case "ThirdBase":
                BaseToMoveTo = HomeBase;
                break;
        }
    }

    void SetNextBase() {
        switch (CurrentBase.tag) {
            case "HomeBase":
                CurrentBase = FirstBase;
                break;
            case "FirstBase":
                CurrentBase = SecondBase;
                break;
            case "SecondBase":
                CurrentBase = ThirdBase;
                break;
            case "ThirdBase":
                CurrentBase = HomeBase;
                break;
        }
    }

    public bool PlayerHasSwung() {
        return HasSwung;
    }

    public void SetHasSwung(bool val) {
        HasSwung = val;
    }

    public bool HasHitBall() {
        return HitBall;
    }

    void SetHasSwung() {
        HasSwung = true;
    }

    void ResetHasSwung() {
        HasSwung = false;
    }
}
