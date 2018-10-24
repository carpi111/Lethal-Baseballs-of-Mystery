using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] Fielders = new GameObject[7];

    int NumStrikes;
    bool BallInHitBox;

	void Start () {
        Fielders = GameObject.FindGameObjectsWithTag("Fielder");
    }

    public void SetBallInHitBox(bool val) {
        BallInHitBox = val;
    }

    public bool IsBallInHitBox() {
        return BallInHitBox;
    }

    public int GetStrikesCount()
    {
        return NumStrikes;
    }
}
