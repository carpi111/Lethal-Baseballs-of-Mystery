﻿using UnityEngine;

public class PitcherController : MonoBehaviour {

    public BaseballController Baseball;
    public Transform PitchPoint;
    public Material GoodBallMaterial;
    public Material BadBallMaterial;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButton(0)) {
            var newBaseball = Instantiate(Baseball, PitchPoint.position, PitchPoint.rotation);
            int random = Random.Range(0, 100);
            newBaseball.GetComponent<MeshRenderer>().material = random % 2 == 0 ? GoodBallMaterial : BadBallMaterial;
        }
	}
}
