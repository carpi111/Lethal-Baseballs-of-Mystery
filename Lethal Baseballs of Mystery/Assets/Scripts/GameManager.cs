using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] Fielders = new GameObject[7];
    public Transform PitchTarget;
    public AudioSource StrikeSound;
    public AudioSource OutSound;
    public AudioSource HeyBatterBatterSound;

    int NumStrikes;
    bool BallInHitBox;
    bool BallExitedHitBox;
    bool NeedsNewBatter;

    PitcherController Pitcher;
    BatterController Batter;
    BaseballController Baseball;
    Transform BaseballTargetPos;

	void Start() {
        Fielders = GameObject.FindGameObjectsWithTag("Fielder");
        Pitcher  = GameObject.FindWithTag("Pitcher").GetComponent<PitcherController>();
        Batter   = GameObject.FindWithTag("Batter").GetComponent<BatterController>();
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
        if (NumStrikes < 3) {
            StrikeSound.Play();
        } else {
            OutSound.Play();
            NumStrikes = 0;
        }
    }

    public Transform GetPitchTarget() {
        return PitchTarget;
    }

    public Transform GetRandomFielderPosition() {
        int random = Random.Range(0, 7);

        return Fielders[random].transform;
    }

    public void SetBatterTagToRunner() {
        Batter.tag = "Runner";
    }

    public void SetBaseball(GameObject ball) {
        Baseball = ball.GetComponent<BaseballController>();
    }

    public BaseballController GetBaseball() {
        return Baseball;
    }

    public void NewBatter() {
        Invoke("MakeNewBatter", 2);
    }

    public void SetNeedsNewBatter(bool val) {
        NeedsNewBatter = val;
    }

    public bool GetNeedsNewBatter() {
        return NeedsNewBatter;
    }

    void MakeNewBatter() {
        Instantiate(Batter);
        HeyBatterBatterSound.Play();
    }
}
