using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] Fielders = new GameObject[7];
    public Transform PitchTarget;

    int NumStrikes;
    bool BallInHitBox;
    bool BallExitedHitBox;

    PitcherController Pitcher;
    BatterController Batter;

	void Start() {
        Fielders = GameObject.FindGameObjectsWithTag("Fielder");
        Pitcher = GameObject.FindWithTag("Pitcher").GetComponent<PitcherController>();
        Batter = GameObject.FindWithTag("Batter").GetComponent<BatterController>();
    }

    public PitcherController GetPitcher() {
        return Pitcher;
    }

    public BatterController GetBatter() {
        return Batter;
    }

    public void SetBallInHitBox(bool val) {
        BallInHitBox = val;
    }

    public bool BallIsInHitBox() {
        return BallInHitBox;
    }

    public void SetBallExitedHitBox(bool val) {
        BallExitedHitBox = val;
    }

    public bool BallDidExitHitBox() {
        return BallExitedHitBox;
    }

    public int GetStrikesCount() {
        return NumStrikes;
    }

    public void AddStrike() {
        NumStrikes++;
    }

    public Transform GetPitchTarget() {
        return PitchTarget;
    }
}
